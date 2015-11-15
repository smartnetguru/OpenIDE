using System.Windows.Forms;
using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Completion;
using System.Collections.Generic;
using System.Linq;

namespace OpenIDE.Core.Extensibility.ScriptedProviders
{
    public class ScriptedCompletionProvider : AbstractCompletionDataProvider
    {
        private List<string> _callback;
        public ScriptedCompletionProvider(List<string> callback)
        {
            _callback = callback;
        }

        public override ImageList ImageList => new ImageList();

        public override ICompletionData[] GenerateCompletionData(string fileName, TextArea textArea, char charTyped)
        {
            return (from c in _callback select new DefaultCompletionData(c, "", -1)).ToArray();
        }
    }
}