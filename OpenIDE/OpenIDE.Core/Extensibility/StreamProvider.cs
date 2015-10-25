using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using DigitalRune.Windows.TextEditor.Highlighting;

namespace OpenIDE.Core.Extensibility
{
    internal class StreamProvider : ISyntaxModeFileProvider
    {
        private Stream highlighting;

        public StreamProvider(Stream highlighting)
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