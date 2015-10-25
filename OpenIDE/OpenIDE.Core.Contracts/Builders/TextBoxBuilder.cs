using Telerik.WinControls.UI;

namespace OpenIDE.Core.Contracts.Builders
{
    public class TextBoxBuilder : ControlBuilder<RadTextBoxControl>
    {
        public TextBoxBuilder Password()
        {
            _control.UseSystemPasswordChar = true;

            return this;
        }

        public TextBoxBuilder Placeholder(string text)
        {
            _control.NullText = text;

            return this;
        }
    }
}