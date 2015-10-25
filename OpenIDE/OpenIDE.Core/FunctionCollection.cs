using System.Collections.Generic;
using System.Linq;

namespace OpenIDE.Core
{
    public class FunctionCollection : List<Function>
    {
        public Function this[string name]
        {
            get
            {
                return Enumerable.Where(this, (f) => f.Name == name).FirstOrDefault();
            }
        }
    }
}