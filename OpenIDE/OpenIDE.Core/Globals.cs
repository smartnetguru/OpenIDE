using OpenIDE.Core;
using OpenIDE.Core.Extensibility;
using System.Drawing;

namespace OpenIDE.Library
{
    public class Globals
    {
        public Plugin plugin;

        public Globals(Plugin _plugin)
        {
            plugin = _plugin;
        }

        public string prompt(string title, string content)
        {
            return Prompt.Show(title, content);
        }

        public void notify(string title, string content)
        {
            NotificationService.Notify(title, content);
        }

        public Color argb(int a, int r, int g, int b)
        {
            return Functions.Argb(r, g, b, a);
        }
        public Color hsla(double h, double s, double l, int a)
        {
            return Functions.Hsla(h, s, l, a);
        }
        public Color hexadecimal(string src)
        {
            return Functions.Hexadecimal(src);
        }

        public void type(string name)
        {
            var t = System.Type.GetType(name);

            plugin._engine.Add(t.Name, t);
        }
    }
}