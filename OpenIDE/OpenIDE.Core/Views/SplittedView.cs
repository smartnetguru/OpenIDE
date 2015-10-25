using OpenIDE.Core.Contracts;
using OpenIDE.Core.Extensibility;
using System.IO;

namespace OpenIDE.Core.Views
{
    public class SplittedView : View
    {
        public SplittedView(ItemTemplate p, View v)
        {
            var editor = EditorBuilder.Build(p.Extension, null, null, null);
            editor.Text = new StreamReader(new MemoryStream(Data)).ReadToEnd();

            v.Data = Data;
            var first = v.GetView();
            first.Dock = System.Windows.Forms.DockStyle.Fill;

            var c = new System.Windows.Forms.SplitContainer();
            c.Panel1.Controls.Add(first);
            c.Panel2.Controls.Add(editor);
        }
    }
}