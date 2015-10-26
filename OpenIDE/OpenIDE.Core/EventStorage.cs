using System.Collections.Generic;

namespace OpenIDE.Core
{
    public class EventStorage
    {
        private Dictionary<string, List<dynamic>> _listeners = new Dictionary<string, List<dynamic>>();

        public void AddListener(string name, dynamic callback)
        {
            if(_listeners.ContainsKey(name))
            {
                var l = _listeners[name];
                l.Add(callback);

                _listeners[name] = l;
            }
            else
            {
                var l = new List<dynamic>();
                l.Add(callback);

                _listeners.Add(name, l);
            }
        }

        public void Fire(string name, object arg = null, object arg2 = null, object arg3 = null)
        {
            foreach (var l in _listeners[name])
            {
                if (arg != null)
                {
                    l(arg);
                }
                else if (arg2 != null)
                {
                    l(arg, arg2);
                }
                else if (arg2 != null)
                {
                    l(arg, arg2, arg3);
                }
                else
                {
                    l();
                }
            }
        }
    }
}