using DigitalRune.Windows.TextEditor;
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

            _view = e;
        }

        public override void Create(byte[] raw)
        {
            var e = (TextEditorControl)_view;
            e.Text = new StreamReader(new MemoryStream(raw)).ReadToEnd();
        }
    }
}