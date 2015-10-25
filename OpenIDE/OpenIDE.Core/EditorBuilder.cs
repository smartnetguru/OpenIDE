using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Completion;
using DigitalRune.Windows.TextEditor.Document;
using DigitalRune.Windows.TextEditor.Folding;
using DigitalRune.Windows.TextEditor.Highlighting;
using DigitalRune.Windows.TextEditor.Insight;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenIDE.Core
{
    public class EditorBuilder
    {
        private static AbstractCompletionDataProvider _completionProvider = null;
        private static AbstractInsightDataProvider _insight = null;

        public static TextEditorControl Build(string highlighting, 
            AbstractCompletionDataProvider completionProvider, IFoldingStrategy foldingStrategy, 
            AbstractInsightDataProvider insight)
        {
            var ret = new TextEditorControl();

            /*_completionProvider = completionProvider;
            _insight = insight;
            
            ret.Document.FormattingStrategy = new CSharpFormattingStrategy();
            ret.Document.FoldingManager.FoldingStrategy = foldingStrategy;

            ret.CompletionRequest += new EventHandler<CompletionEventArgs>(CompletionRequest);
            ret.InsightRequest += new EventHandler<InsightEventArgs>(InsightRequest);
            ret.ToolTipRequest += new EventHandler<ToolTipRequestEventArgs>(ToolTipRequest);
            */

            ret.Dock = DockStyle.Fill;

            Font consolasFont = new Font("Consolas", 9.75f);
            ret.Font = consolasFont;

            var timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 2000;
            timer.Tick += new EventHandler(UpdateFoldings);
            timer.Tag = ret;

            ret.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighterForFile(highlighting);

            return ret;
        }

        private static void UpdateFoldings(object sender, EventArgs e)
        {
            var s = (TextEditorControl)((Timer)sender).Tag;
            s?.Document.FoldingManager?.UpdateFolds(null, null);
        }


        private static void CompletionRequest(object sender, CompletionEventArgs e)
        {
            var textEditorControl = (TextEditorControl)sender;

            if (textEditorControl.CompletionWindowVisible)
                return;

            // e.Key contains the key that the user wants to insert and which triggered
            // the CompletionRequest.
            // e.Key == '\0' means that the user triggered the CompletionRequest by pressing <Ctrl> + <Space>.

            if (e.Key == '\0')
            {
                // The user has requested the completion window by pressing <Ctrl> + <Space>.
                textEditorControl.ShowCompletionWindow(_completionProvider, e.Key, false);
            }
            else if (char.IsLetter(e.Key))
            {
                // The user is typing normally. 
                // -> Show the completion to provide suggestions. Automatically close the window if the 
                // word the user is typing does not match the completion data. (Last argument.)
                textEditorControl.ShowCompletionWindow(_completionProvider, e.Key, true);
            }
        }


        private static void InsightRequest(object sender, InsightEventArgs e)
        {
            var textEditorControl = (TextEditorControl)sender;

            textEditorControl.ShowInsightWindow(_insight);
        }


        private static void ToolTipRequest(object sender, ToolTipRequestEventArgs e)
        {
            var textEditorControl = (TextEditorControl)sender;

            if (!e.InDocument || e.ToolTipShown)
                return;

            // Get word under cursor
            TextLocation position = e.LogicalPosition;
            LineSegment line = textEditorControl.Document.GetLineSegment(position.Y);
            if (line != null)
            {
                TextWord word = line.GetWord(position.X);
                if (word != null && !String.IsNullOrEmpty(word.Word))
                    e.ShowToolTip("Current word: \"" + word.Word + "\"\n" + "\nRow: " + (position.Y + 1) + " Column: " + (position.X + 1));
            }
        }
    }
}