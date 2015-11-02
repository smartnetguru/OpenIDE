using DigitalRune.Windows.TextEditor;
using OpenIDE.Core.Contracts;
using OpenIDE.Core.Extensibility;
using OpenIDE.Core.ProjectSystem;

namespace OpenIDE.Core.Views
{
    public class EditorView : View
    {
        bool firstEdit = true;

        public File File { get; set; }

        public EditorView(ItemTemplate p, File f)
        {
            var e = EditorBuilder.Build(p.Extension, null, null, null);
            e.Tag = this;
            this.File = f;

            _view = e;
        }

        public override void Create(byte[] raw)
        {
            var e = (TextEditorControl)_view;
            e.DocumentChanged += (s, ev) =>
            {
                if (!firstEdit)
                {
                    if (!Window.Text.EndsWith("(*)"))
                    {
                        Window.Text = Window.Text + " (*)";
                        Workspace.IsIdle = true;
                        firstEdit = false;
                    }
                    else
                    {
                        // on save remove asteriks
                    }
                }
                else
                {
                    firstEdit = false;
                }
                
            };

            e.Text = new System.IO.StreamReader(new System.IO.MemoryStream(raw)).ReadToEnd();
        }
    }
}