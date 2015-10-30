using OpenIDE.Core.ProjectSystem;
using OpenIDE.Core.Properties;
using OpenIDE.Core.Views;
using Telerik.WinControls.UI;

namespace OpenIDE.Core
{
    public class SolutionExplorer
    {
        public static RadTreeNode Build(Project proj)
        {
            var pn = new RadTreeNode($"Project '{proj.Name}'", true);
            pn.Tag = proj;

            var props = new RadTreeNode("Properties", Resources.Property, true);
            props.Tag = new PropertiesView();
            pn.Nodes.Add(props);

            pn.Expanded = proj.Expandet;

            foreach (var f in proj.Files)
            {
                var n = new RadTreeNode(f.Src);
                n.Tag = f;

                // TODO: Add icon for file

                pn.Nodes.Add(n);
            }

            return pn;
        }

        public static RadTreeNode Build(Solution sol)
        {
            var ret = new RadTreeNode($"Solution '{sol.Name}'", true);
            ret.Tag = sol;

            foreach (var p in sol.Projects)
            {
                var pn = Build(p);

                ret.Nodes.Add(pn);
            }

            return ret;
        }
    }
}