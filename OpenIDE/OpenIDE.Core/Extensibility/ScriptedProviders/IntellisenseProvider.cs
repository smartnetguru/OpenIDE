using System.Windows.Forms;
using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Completion;
using OpenIDE.Library;

namespace OpenIDE.Core.Extensibility.ScriptedProviders
{
    public class IntellisenseProvider : AbstractCompletionDataProvider
    {
        private Intellisense _intellisense;
        public IntellisenseProvider(Intellisense intellisense)
        {
            _intellisense = intellisense;
        }

        public override ImageList ImageList => new ImageList();

        public override ICompletionData[] GenerateCompletionData(string fileName, TextArea textArea, char charTyped)
        {
            return _intellisense._data.ToArray();
        }
    }
}