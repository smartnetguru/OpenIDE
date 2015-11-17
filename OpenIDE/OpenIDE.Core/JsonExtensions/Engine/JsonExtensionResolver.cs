using OpenIDE.Core.JsonExtensions;
using System.Collections.Generic;
using Ionic.Zip;

namespace OpenIDE.Core
{
    public abstract class IExtension
    {
        public abstract string Name { get; }
        public abstract object ProvideValue(MarkupExtension me);
        public ZipFile Archive { get; set; }
    }

    public static class JsonExtensionResolver
    {
        private static List<IExtension> _extensions = new List<IExtension>();

        public static ZipFile Archive { get; internal set; }

        public static void Init()
        {
            AddExtension(new GuidExtension());
            AddExtension(new RessourceExtension());
        }

        static JsonExtensionResolver()
        {
            Init();
        }

        public static void AddExtension(IExtension extension)
        {
            _extensions.Add(extension);
        }

        public static T Resolve<T>(string src)
            where T : class
        {

            foreach (var e in _extensions)
            {
                var me = MarkupExtensionParser.Parse(src);

                if(me.Name == null)
                {
                    return src as T;
                }
                else
                {
                    e.Archive = Archive;

                    return e.ProvideValue(me) as T;
                }
            }

            throw new KeyNotFoundException("Extension not found");
        }
    }
}