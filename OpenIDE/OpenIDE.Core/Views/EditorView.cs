using OpenIDE.Core.Contracts;
using OpenIDE.Core.Extensibility;
using System.IO;

namespace OpenIDE.Core.Views
{
    public class EditorView : View
    {
        public EditorView(ItemTemplate p)
        {
            var e = EditorBuilder.Build(p.Extension, null, null, null);
            e.Text = new StreamReader(new MemoryStream(Data)).ReadToEnd();

            _view = e;
        }
    }
}