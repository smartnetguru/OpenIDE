using System.Windows.Forms;

namespace OpenIDE.Core
{
    public partial class StartPage : UserControl
    {
        public StartPage()
        {
            InitializeComponent();

            TranslateLanguage();
        }

        void TranslateLanguage()
        {
            startLabel.Text = LanguageManager._("Start");
            newProjectLink.Text = LanguageManager._("New Project");
            openProjectLink.Text = LanguageManager._("Open Project");
        }
    }
}