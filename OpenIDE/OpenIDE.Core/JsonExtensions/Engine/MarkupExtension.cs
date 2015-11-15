using System.Collections.Generic;

namespace OpenIDE.Core
{
    public class MarkupExtension
    {
        public string Name { get; set; }
        public List<string> Arguments { get; set; }

        public static MarkupExtension Empty => new MarkupExtension();

        public MarkupExtension()
        {
            Arguments = new List<string>();
        }
    }
}