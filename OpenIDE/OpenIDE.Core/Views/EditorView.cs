using OpenIDE.Core.Contracts;
using OpenIDE.Core.Extensibility;

namespace OpenIDE.Core.Views
{
    public class EditorView : View
    {
        public EditorView(ItemTemplate p)
        {
            this._view = EditorBuilder.Build(p.Extension, null, null, null);
        }
    }
}