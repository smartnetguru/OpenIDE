using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace OpenIDE.Core
{
    public partial class StartPage : UserControl
    {
        public StartPage()
        {
            InitializeComponent();

           /* var rss = new RssManager("");

            foreach (var feed in rss.GetFeed())
            {
                var item = new RadListDataItem();
                item.Text = feed.Title;
                

                newsList.Items.Add(item);
            }*/

            TranslateLanguage();
        }

        void TranslateLanguage()
        {
            startLabel.Text = LanguageManager._("Start");
            newsLabel.Text = LanguageManager._("News");
            newProjectLink.Text = LanguageManager._("New Project");
            openProjectLink.Text = LanguageManager._("Open Project");
        }
    }
}