using System.Windows.Forms;
using System.Xaml;

namespace OpenIDE.Core.Contracts
{
    public class View
    {
        protected Control _view;

        public byte[] Data { get; set; }

        public static View FromXaml(string src)
        {
            var ui = XamlServices.Parse(src) as UserControl;
            ui.Dock = DockStyle.Fill;

            return new View() { _view = ui };
        }

        public static View FromBuilder(ViewBuilder vw)
        {
            var v = new View() { _view = vw.Build() };

            v._view.Dock = DockStyle.Fill;

            return v;
        }

        public Control GetView()
        {
            return _view;
        }
    }
}