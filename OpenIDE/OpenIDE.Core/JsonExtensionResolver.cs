using OpenIDE.Core.JsonExtensions;
using System.Collections.Generic;

namespace OpenIDE.Core
{
    public interface IExtension
    {
        object ProvideValue();
    }

    public static class JsonExtensionResolver
    {
        private static Dictionary<string, IExtension> _extensions = new Dictionary<string, IExtension>();

        public static void Init()
        {
            AddExtension("{guid}", new GuidExtension());
        }

        public static void AddExtension(string ext, IExtension extension)
        {
            _extensions.Add(ext, extension);
        }

        public static T Resolve<T>(string src)
            where T : class
        {
            if(_extensions.ContainsKey(src.ToLower().Trim()))
            {
                return _extensions[src].ProvideValue() as T;
            }
            else
            {
                throw new KeyNotFoundException("Extension not found");
            }
        }
    }
}