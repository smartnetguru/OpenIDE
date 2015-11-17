using System.Collections.Generic;

namespace OpenIDE.Library
{
    public class Intellisense
    {
        public List<DigitalRune.Windows.TextEditor.Completion.DefaultCompletionData> _data 
            = new List<DigitalRune.Windows.TextEditor.Completion.DefaultCompletionData>();

        public void Add(string title, string description, int imageindex = -1)
        {
            _data.Add(new DigitalRune.Windows.TextEditor.Completion.DefaultCompletionData(title, description, imageindex));
        }
    }
}