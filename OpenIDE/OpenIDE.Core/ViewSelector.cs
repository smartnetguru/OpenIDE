using OpenIDE.Core.Contracts;
using OpenIDE.Core.Extensibility;
using OpenIDE.Core.Extensibility.ScriptedProviders;
using OpenIDE.Core.ProjectSystem;
using OpenIDE.Core.Views;
using Telerik.WinControls.UI.Docking;

namespace OpenIDE.Core
{
    public class ViewSelector
    {
        public static View Select(ItemTemplate it, byte[] data, File file, IntellisenseProvider intellisenseOProvider, DockWindow window = null)
        {
            if(it.View != null)
            {
                it.View.Window = window;

                it.View.Create(data);

                return it.View;
            }
            else
            {
                var v = new EditorView(it, file);
                v.Window = window;
                v.IntellisenseProvider = intellisenseOProvider;

                v.Create(data);
                
                return v;
            }
        }
    }
}