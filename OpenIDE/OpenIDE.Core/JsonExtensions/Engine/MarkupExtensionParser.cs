using System;

namespace OpenIDE.Core
{
    public class MarkupExtensionParser
    {
        public static MarkupExtension Parse(string src)
        {
            src = src.Trim();
            var result = new MarkupExtension();

            if(src.StartsWith("{") && src.EndsWith("}"))
            {
                var t = src.TrimStart('{').TrimEnd('}');
                var spl = t.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                result.Name = spl[0];

                if (spl.Length > 0)
                {
                    var args = spl[1].Split(new[] { ',' });

                    result.Arguments.AddRange(args);
                }

                return result;
            }
            return MarkupExtension.Empty;
        }
    }
}