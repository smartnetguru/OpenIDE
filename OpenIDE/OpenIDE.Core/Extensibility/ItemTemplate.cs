﻿using OpenIDE.Core.Contracts;
using OpenIDE.Core.Extensibility.ScriptedProviders;
using OpenIDE.Library;
using System;
using System.Drawing;

namespace OpenIDE.Core.Extensibility
{
    public class ItemTemplate
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public string Highlighting { get; set; }
        public Image Icon { get; set; }
        public Guid ProjectID { get; set; }
        public string Extension { get; set; }
        public View View { get; internal set; }
        public string ViewSource { get; internal set; }
        public byte[] Raw { get; set; }
        public DigitalRune.Windows.TextEditor.Completion.AbstractCompletionDataProvider AutoCompletionProvider { get; set; }
        public Intellisense Intellisense { get; set; }
        public Plugin Plugin { get; set; }

        public ItemTemplate(Plugin plugin)
        {
            Name = "";
            ID = Guid.Empty;
            Intellisense = new Intellisense();

            AutoCompletionProvider = new IntellisenseProvider(Intellisense);
            Plugin = plugin;
        }
    }
}