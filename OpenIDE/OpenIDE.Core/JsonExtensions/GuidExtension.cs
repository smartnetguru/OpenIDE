using System;

namespace OpenIDE.Core.JsonExtensions
{
    public class GuidExtension : IExtension
    {
        public override string Name => "guid";

        public override object ProvideValue(MarkupExtension me)
        {
            return Guid.NewGuid().ToString();
        }
    }
}