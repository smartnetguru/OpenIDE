using Ionic.Zlib;
using System.Collections.Generic;
using System.IO;
using System.Xaml;

namespace OpenIDE.Core
{
    public class Settings
    {
        private Dictionary<string, object> _data = new Dictionary<string, object>();

        public void Add(string name, object value)
        {
            if(_data.ContainsKey(name))
            {
                _data[name] = value;
            }
            else
            {
                _data.Add(name, value);
            }
        }

        public T Get<T>(string name)
        {
            if(_data.ContainsKey(name))
            {
                return (T)_data[name];
            }

            return default(T);
        }

        public void Save()
        {
            using (var fileStream = File.Open("settings.db", FileMode.OpenOrCreate))
            {
                using (var stream = new GZipStream(fileStream, CompressionMode.Compress))
                {
                    XamlServices.Save(stream, _data);
                }
            }
        }

        public void Load()
        {
            try
            {
                using (var fileStream = File.Open("settings.db", FileMode.OpenOrCreate))
                {
                    using (var stream = new GZipStream(fileStream, CompressionMode.Decompress))
                    {
                        _data = (Dictionary<string, object>)XamlServices.Load(stream);
                    }
                }
            }
            catch
            {
                Save();
                Load();
            }
        }
    }
}