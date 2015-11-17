using System.Collections.Generic;

namespace OpenIDE.Library
{
    public class Intellisense
    {
        public List<DigitalRune.Windows.TextEditor.Completion.ICompletionData> _data 
            = new List<DigitalRune.Windows.TextEditor.Completion.ICompletionData>();

        public void Add(string title, string description, int imageindex = -1)
        {
            _data.Add(new DigitalRune.Windows.TextEditor.Completion.DefaultCompletionData(title, description, imageindex));
        }
        public void AddSnippet(string shortcut, string text, int imageIndex = -1)
        {
            _data.Add(new DigitalRune.Windows.TextEditor.Completion.SnippetCompletionData(
                new DigitalRune.Windows.TextEditor.Completion.Snippet(shortcut, text), imageIndex));
        }
    }
}