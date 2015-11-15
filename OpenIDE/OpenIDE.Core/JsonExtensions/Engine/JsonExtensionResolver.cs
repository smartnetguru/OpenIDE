using OpenIDE.Core.JsonExtensions;
using System.Collections.Generic;

namespace OpenIDE.Core
{
    public interface IExtension
    {
        string Name { get; }
        object ProvideValue(MarkupExtension me);
    }

    public static class JsonExtensionResolver
    {
        private static List<IExtension> _extensions = new List<IExtension>();

        public static void Init()
        {
            AddExtension(new GuidExtension());
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

                if(me.Name == "")
                {
                    return src as T;
                }
                else
                {
                    return e.ProvideValue(me) as T;
                }
            }

            throw new KeyNotFoundException("Extension not found");
        }
    }
}