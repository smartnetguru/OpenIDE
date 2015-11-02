using OpenIDE.Core.Contracts;
using OpenIDE.Core.Extensibility;
using OpenIDE.Core.Views;
using Telerik.WinControls.UI.Docking;

namespace OpenIDE.Core
{
    public class ViewSelector
    {
        public static View Select(ItemTemplate it, byte[] data, DockWindow window = null)
        {
            if(it.View != null)
            {
                it.View.Data = data;
                it.View.Window = window;

                it.View.Create(data);

                return it.View;
            }
            else
            {
                var v = new EditorView(it);
                v.Data = data;
                v.Window = window;

                v.Create(data);
                
                return v;
            }
        }
    }
}