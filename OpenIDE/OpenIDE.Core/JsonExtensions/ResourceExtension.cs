using System;

namespace OpenIDE.Core.JsonExtensions
{
    public class RessourceExtension : IExtension
    {
        public override string Name => "ressource";

        public override object ProvideValue(MarkupExtension me)
        {
            return Archive[me.Arguments[0]].OpenReader();
        }
    }
}