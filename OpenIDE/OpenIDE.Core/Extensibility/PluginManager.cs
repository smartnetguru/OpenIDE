using OpenIDE.Core.Extensibility;
using System.IO;

namespace OpenIDE.Core
{
    public class PluginManager
    {
        public PluginCollection Plugins { get; set; }

        public PluginManager()
        {
            Plugins = new PluginCollection();
        }

        public void Load(string path)
        {
            foreach (var item in Directory.GetFiles(path, "*.plugin"))
            {
                var p = Plugin.Load(item);

                Plugins.Add(p);
            }
        }
    }
}