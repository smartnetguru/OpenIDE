using OpenIDE.Core.Contracts.Builders;
using System.Windows.Forms;
using Telerik.WinControls;

namespace OpenIDE.Core.Contracts
{
    public class ViewBuilder
    {
        private FlowLayoutPanel _view;

        ViewBuilder()
        {
            _view = new FlowLayoutPanel();
        }

        public static ViewBuilder Factory()
        {
            return new ViewBuilder();
        }

        public TextBoxBuilder TextBox()
        {
            var tbB = new TextBoxBuilder();
            _view.Controls.Add(tbB.Build());

            return tbB;
        }

        public ControlBuilder<T> Generic<T>()
            where T : Control, new()
        {
            var tbB = new ControlBuilder<T>();
            _view.Controls.Add(tbB.Build());

            if(tbB._control is RadControl)
            {
                var l = tbB._control as RadControl;
                l.ThemeName = "VisualStudio2012Dark";
            }

            return tbB;
        }

        public Control Build()
        {
            return _view;
        }
    }
}