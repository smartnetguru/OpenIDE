using OpenIDE.Core.Localisation;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OpenIDE.Core
{
    public static class LanguageManager
    {
        private static BaseCatalog _catalog;

        public static void Init(System.Globalization.CultureInfo culture)
        {
            _catalog = new Catalog(culture.Name, Application.StartupPath + "\\locale\\", culture);
        }

        public static string _(string id)
        {
            if(_catalog == null)
            {
                return id;
            }

            return _catalog.GetString(id);
        }

        public static IEnumerable<string> GetAvailablesLanguages()
        {
            foreach (var f in Directory.GetDirectories(Application.StartupPath + "\\locale\\"))
            {
                yield return new DirectoryInfo(f).Name.Replace("_", "-");
            }
        }
    }
}