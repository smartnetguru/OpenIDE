using DigitalRune.Windows.TextEditor;
using OpenIDE.Core.Contracts;
using OpenIDE.Core.Extensibility;
using System.IO;

namespace OpenIDE.Core.Views
{
    public class EditorView : View
    {
        bool firstEdit = false;

        public EditorView(ItemTemplate p)
        {
            var e = EditorBuilder.Build(p.Extension, null, null, null);
            
            _view = e;
        }

        public override void Create(byte[] raw)
        {
            var e = (TextEditorControl)_view;
            e.DocumentChanged += (s, ev) =>
            {
                if (!firstEdit)
                {
                    if (!Window.Text.EndsWith(" (*)"))
                    {
                        Window.Text = Window.Text + " (*)";
                        Workspace.IsIdle = true;
                        firstEdit = true;
                    }
                }
            };

            e.Text = new StreamReader(new MemoryStream(raw)).ReadToEnd();
        }
    }
}