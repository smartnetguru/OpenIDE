using System.Windows.Forms;
using System.Xaml;
using Telerik.WinControls.UI.Docking;

namespace OpenIDE.Core.Contracts
{
    public class View
    {
        protected Control _view;

        public DockWindow Window { get; set; }

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

        public virtual void Create(byte[] raw)
        {

        }

        public Control GetView()
        {
            return _view;
        }
    }
}