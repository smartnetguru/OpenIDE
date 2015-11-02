using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using DigitalRune.Windows.TextEditor.Highlighting;

namespace OpenIDE.Core.Extensibility
{
    public class StreamProvider : ISyntaxModeFileProvider
    {
        private Stream highlighting;

        public StreamProvider(Stream highlighting, string name)
        {
            this.highlighting = highlighting;
        }

        public ICollection<SyntaxMode> SyntaxModes => new List<SyntaxMode>();

        public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
        {
            return new XmlTextReader(highlighting);
        }

        public void UpdateSyntaxModeList()
        {

        }
    }
}