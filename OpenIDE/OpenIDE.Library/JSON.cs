using Lib.JSON;

namespace OpenIDE.Library
{
    public class JSON
    {
        public string stringify(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented);
        }

        public object parse(string s)
        {
            return JsonConvert.DeserializeObject(s);
        }
    }
}