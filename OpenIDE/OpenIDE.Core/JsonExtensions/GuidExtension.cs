using System;

namespace OpenIDE.Core.JsonExtensions
{
    public class GuidExtension : IExtension
    {
        public string Name => "guid";

        public object ProvideValue()
        {
            return Guid.NewGuid().ToString();
        }

        public object ProvideValue(MarkupExtension me)
        {
            return Guid.NewGuid().ToString();
        }
    }
}