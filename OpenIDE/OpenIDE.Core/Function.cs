using OpenIDE.Core.PropertyBag;

namespace OpenIDE.Core
{
    public class Function : ComplexProperty
    {
        public string Name
        {
            get { return GetValue<string>("Name"); }
            set { SetValue("Name", value); }
        }

        public string Description
        {
            get { return GetValue<string>("Description"); }
            set { SetValue("Description", value); }
        }

        public string Args
        {
            get { return GetValue<string>("Args"); }
            set { SetValue("Args", value); }
        }
    }
}