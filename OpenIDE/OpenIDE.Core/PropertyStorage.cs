using System.Collections.Generic;

namespace OpenIDE.Core
{
    public class PropertyStorage
    {
        private Dictionary<string, object> _properties = new Dictionary<string, object>();

        public void Set(string name, object obj)
        {
            if(_properties.ContainsKey(name))
            {
                _properties[name] = obj;
            }
            else
            {
                _properties.Add(name, obj);
            }
        }

        public object Get(string name)
        {
            if(_properties.ContainsKey(name))
            {
                return _properties[name];
            }

            else
            {
                return null;
            }
        }
    }
}