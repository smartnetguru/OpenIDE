using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace OpenIDE.Library
{
    public class Intellisense
    {
        public List<DigitalRune.Windows.TextEditor.Completion.ICompletionData> _data 
            = new List<DigitalRune.Windows.TextEditor.Completion.ICompletionData>();

        public List<Image> _icons = new List<Image>();

        public void Add(string title, string description, int imageindex = -1)
        {
            _data.Add(new DigitalRune.Windows.TextEditor.Completion.DefaultCompletionData(title, description, imageindex));
        }
        public void AddSnippet(string shortcut, string text, int imageIndex = -1)
        {
            _data.Add(new DigitalRune.Windows.TextEditor.Completion.SnippetCompletionData(
                new DigitalRune.Windows.TextEditor.Completion.Snippet(shortcut, text), imageIndex));
        }

        public void AddIcon(Stream iconStrm)
        {
            _icons.Add(Image.FromStream(iconStrm));
        }
    }
}