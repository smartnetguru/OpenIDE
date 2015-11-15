using Creek.Scripting;
using DigitalRune.Windows.TextEditor.Highlighting;
using Ionic.Zip;
using Microsoft.ClearScript;
using Microsoft.ClearScript.Windows;
using OpenIDE.Core.Contracts;
using OpenIDE.Core.JSON;
using OpenIDE.Core.Properties;
using OpenIDE.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace OpenIDE.Core.Extensibility
{
    public class Plugin : IDisposable
    {
        public Dictionary<string, Image> Icons { get; set; }
        public List<ItemTemplate> ItemTemplates { get; set; }
        public List<ProjectTemplate> ProjectTemplates { get; set; }
        public IDictionary<string, object> Info { get; set; }
        public PropertyStorage Properties = new PropertyStorage();
        public List<Library> Dependencies { get; set; }
        public WindowCollection Windows { get; set; }
        public string Filename { get; set; }
        public EventStorage Events { get; set; }

        public delegate object StaticMethodFunc(params object[] args);

        internal WindowsScriptEngine _engine;

        private Plugin()
        {            
            Icons = new Dictionary<string, Image>();
            ItemTemplates = new List<ItemTemplate>();
            ProjectTemplates = new List<ProjectTemplate>();

            Dependencies = new List<Library>();

            Events = new EventStorage();
            Windows = new WindowCollection();
        }

        private void InitEngine(ZipFile z)
        {
            _engine.Execute(Resources.Module);

            _engine.Add("host", new ExtendedHostFunctions());

            // add function to script engine to control the properties
            _engine.Add<Delegate>("property", new StaticMethodFunc(args =>
            {
                if (args.Length == 1)
                {
                    return Properties.Get(args[0].ToString());
                }
                else if (args.Length == 2)
                {
                    Properties.Set(args[0].ToString(), args[1]);

                    return null;
                }

                return null;
            }));
            /*_engine.Add("require", new Action<string>(_ =>
            {
                var i = new StreamReader(z[_].OpenReader());

                _engine.Execute(i.ReadToEnd());
            }));*/
            _engine.Add("import", new Action<string>(_ =>
            {
                var l = Library.Load(_);
                l.Apply(_engine);

                Dependencies.Add(l);
            }));

            _engine.AddHostObject("globals", HostItemFlags.GlobalMembers, new Globals(this));

            _engine.Add("math", new OpenIDE.Library.Math());
            _engine.Add("JSON", new OpenIDE.Library.JSON());
            _engine.Add("XmlHttpRequest", typeof(XmlHttpRequest));
            _engine.Add("console", new OpenIDE.Library.Console.FirebugConsole());

            _engine.Add("register_window", new Action<string, Window>((n, w) => Windows.Add(n, w)));

            _engine.Add("debug", Workspace.Output);
            _engine.Add("register_completion", new Action<string, dynamic>((id, _) => {
                foreach (var item in ItemTemplates)
                {
                    if(item.ID == Guid.Parse(id))
                    {
                        //item.AutoCompletionProvider = new ScriptedCompletionProvider(new List<string>(_));
                    }
                }
            }));

            Events.Fire("OnReady");
        }

        public static Plugin Load(string name)
        {
            var p = new Plugin();

            var z = new ZipFile(name);
            var parts = z.Entries;
            var pa = parts.ToList();

            StringBuilder sources = new StringBuilder();

            for (int i = 0; i < pa.Count; i++)
            {
                var part = pa[i];

                if (part.FileName.StartsWith("Icons") && !part.IsDirectory)
                {
                    var strm = part.OpenReader();

                    var img = Image.FromStream(strm);
                    var n = part.FileName.Remove(0, "Icons/".Length);

                    p.Icons.Add(n, img);
                }
                if (part.FileName.EndsWith(".js") && part.FileName.StartsWith("Sources/"))
                {
                    var src = new StreamReader(z[part.FileName].OpenReader()).ReadToEnd();
                    sources.AppendLine(src);
                }
                if (part.FileName == "info.json")
                {
                    var json = new StreamReader(part.OpenReader()).ReadToEnd();

                    p.Info = ((ObjectValue)Json.Parse(json)).Value;
                    p.Filename = name;
                }
            }

            p.ReadItemtemplates(z);

            p._engine = new JScriptEngine(WindowsScriptEngineFlags.EnableJITDebugging);

            p.InitEngine(z);
            p.ReadDependencies();

            p._engine.Execute(sources.ToString());
            p._engine.Execute(new StreamReader(z["main.js"].OpenReader()).ReadToEnd());

            return p;
        }

        private void ReadDependencies()
        {
            if(Info.ContainsKey("Dependencies"))
            {
                var v = Info["Dependencies"] as ArrayValue;
                foreach (var item in v.Value)
                {
                    var l = Library.Load(item.ToString());
                    
                    l?.Apply(_engine);

                    Dependencies.Add(l);
                }
            }
        }

        public void AddEventListener(string name, dynamic callback)
        {
            Events.AddListener(name, callback);
        }

        private void ReadItemtemplates(ZipFile z)
        {
            var t = Info["Templates"] as ObjectValue;
            var items = (t.Value["Item"] as ArrayValue).Value;

            foreach (var tt in items)
            {
                var obj = (tt as ObjectValue).Value;
                var te = new ItemTemplate();

                te.ProjectID = Guid.Parse(JsonExtensionResolver.Resolve<string>(Info["ID"].ToString()));

                te.Name = obj["Name"].ToString();
                te.Extension = obj["Extension"].ToString();
                te.ID = Guid.Parse(JsonExtensionResolver.Resolve<string>(obj["ID"].ToString()));

                var ms = new MemoryStream();
                z["Templates/Items/" + obj["Template"]].OpenReader().CopyTo(ms);

                te.Raw = ms.ToArray();

                if (Icons.Count > 0)
                {
                    te.Icon = Icons[obj["Icon"].ToString()];
                    SolutionExplorer.Icons.Add(te.ID, ResizeIcon(te.Icon, new Size(16, 16)));
                }

                if(obj.ContainsKey("View"))
                {
                    te.View = View.FromXaml(new StreamReader(z["Views/" + obj["View"]].OpenReader()).ReadToEnd());
                    te.ViewSource = new StreamReader(z["Sources/" + obj["View"].ToString().Replace("xaml", "js")].OpenReader()).ReadToEnd();
                }

                var h = z["Highlighting/" + obj["Highlighting"].ToString()];
                te.Highlighting = obj["Highlighting"].ToString();

                var hs = HighlightingDefinitionParser.Parse(new SyntaxMode(te.Highlighting, te.Name, te.Extension), 
                    new XmlTextReader(h.OpenReader()));
                
                HighlightingManager.Manager.AddHighlightingStrategy(hs);
                hs.ResolveReferences();

                ItemTemplates.Add(te);
            }
        }

        private Image ResizeIcon(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        public void Dispose()
        {
            Dependencies = null;
            Filename = null;
            Icons = null;
            Info = null;
            ItemTemplates = null;
            ProjectTemplates = null;
            Properties = null;
            _engine = null;
        }
    }
}