using System.Windows.Forms;
using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Completion;
using OpenIDE.Library;

namespace OpenIDE.Core.Extensibility.ScriptedProviders
{
    public class IntellisenseProvider : AbstractCompletionDataProvider
    {
        private Intellisense _intellisense;
        private ImageList _images = new ImageList();

        public IntellisenseProvider(Intellisense intellisense)
        {
            _intellisense = intellisense;
        }

        public override ImageList ImageList => _images;

        public override ICompletionData[] GenerateCompletionData(string fileName, TextArea textArea, char charTyped)
        {
            foreach (var item in _intellisense._icons)
            {
                _images.Images.Add(item);
            }

            return _intellisense._data.ToArray();
        }
    }
}