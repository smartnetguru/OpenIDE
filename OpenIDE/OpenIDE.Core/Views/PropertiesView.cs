using OpenIDE.Core.Contracts;
using OpenIDE.Core.Options;

namespace OpenIDE.Core.Views
{
    public class PropertiesView : View
    {
        public PropertiesView()
        {
            var props = new ProjectProperties();
            props.Dock = System.Windows.Forms.DockStyle.Fill;

            var tp = new TabPage();
            tp.Controls.Add(new System.Windows.Forms.Button());

            var ti = new TabItem("General", tp);
            
            props.TabItems.Add(ti);
            props.TabItems.Add(new TabItem("Signing"));
            props.TabItems.Add(new TabItem("Reference Paths"));
            props.TabItems.Add(new TabItem("Build Events"));
            props.TabItems.Add(new TabItem("Build"));
            props.TabItems.Add(new TabItem("Debug"));

            foreach (TabItem item in props.TabItems)
            {
                item.ForeColor = System.Drawing.Color.FromArgb(37, 37, 38);
            }

            _view = props;
        }
    }
}