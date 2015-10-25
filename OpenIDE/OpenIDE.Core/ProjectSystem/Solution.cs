using System.Windows.Markup;
using System.Xaml;

namespace OpenIDE.Core.ProjectSystem
{
    [ContentProperty("Projects")]
    public class Solution
    {
        public string Name { get; set; }
        public ProjectCollection Projects { get; set; }

        public Solution()
        {
            Projects = new ProjectCollection();
        }

        public void Save(string filename)
        {
            XamlServices.Save(filename, this);
        }

        public static Solution Load(string filename)
        {
            return (Solution)XamlServices.Load(filename);
        }
    }
}