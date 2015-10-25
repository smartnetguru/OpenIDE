using Ionic.Zip;
using Microsoft.ClearScript.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenIDE.Core.Extensibility
{
    public class Library
    {
        public Dictionary<string, Stream> Sources => new Dictionary<string, Stream>();

        public static Library Load(string name)
        {
            if (File.Exists(name))
            {
                var p = new Library();

                var z = new ZipFile(name);
                var parts = z.Entries;
                var pa = parts.ToList();

                foreach (var item in pa)
                {
                    if (!item.IsDirectory)
                    {
                        p.Sources.Add(item.FileName, item.OpenReader());
                    }
                }

                return p;
            }

            return null;
        }

        public void Apply(WindowsScriptEngine wse, string Language)
        {
            foreach (var item in Sources)
            {
                var src = new StreamReader(item.Value);

                if(Language == "JavaScript")
                {
                    if(item.Key.EndsWith(".js"))
                    {
                        wse.Execute(src.ReadToEnd());
                    }
                }
                else
                {
                    if (item.Key.EndsWith(".vbs"))
                    {
                        wse.Execute(src.ReadToEnd());
                    }
                }
            }
        }
    }
}