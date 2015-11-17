using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace OpenIDE.Core
{
    public partial class StartPage : UserControl
    {
        private EventHandler _open, _newProj;

        public StartPage(EventHandler open, EventHandler newProj)
        {
            InitializeComponent();

            var rss = new RssManager("http://furesoft.de/rss.php");

            var feeds = rss.GetFeed();

            foreach (var feed in feeds)
            {
                var item = new RadListDataItem();
                item.Text = feed.Title;
                
                newsList.Items.Add(item);
            }

            _open = open;
            _newProj = newProj;

            TranslateLanguage();
        }

        private void newProjectLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _newProj.Invoke(sender, e);
        }

        private void openProjectLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _open.Invoke(sender, e);
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