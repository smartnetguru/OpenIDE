using System;

namespace OpenIDE.Core.JsonExtensions
{
    public class IconExtension : IExtension
    {
        public override string Name => "icon";

        public override object ProvideValue(MarkupExtension me)
        {
            //ToDo: Implement returning default icon
            throw new NotImplementedException();
        }
    }
}