using System;

namespace OpenIDE.Core.JsonExtensions
{
    public class GuidExtension : IExtension
    {
        public object ProvideValue()
        {
            return Guid.NewGuid().ToString();
        }
    }
}