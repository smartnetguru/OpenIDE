using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace OpenIDE.Core
{
    public static class Prompt
    {
        public static string Show(string text, string caption)
        {
            RadForm prompt = new RadForm();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.Anchor = AnchorStyles.Right;
            prompt.ShowIcon = false;

            RadLabel textLabel = new RadLabel() { Left = 50, Top = 20, Text = text, AutoSize = true };
            RadTextBox textBox = new RadTextBox() { Left = 50, Top = 50, Width = 400 };
            RadButton confirmation = new RadButton() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}