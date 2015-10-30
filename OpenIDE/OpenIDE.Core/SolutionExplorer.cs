using OpenIDE.Core.ProjectSystem;
using OpenIDE.Core.Properties;
using OpenIDE.Core.Views;
using Telerik.WinControls.UI;

namespace OpenIDE.Core
{
    public class SolutionExplorer
    {
        public static RadTreeNode Build(Solution sol)
        {
            var ret = new RadTreeNode($"Solution '{sol.Name}'", true);
            ret.Tag = sol;

            foreach (var p in sol.Projects)
            {
                var pn = new RadTreeNode($"Project '{p.Name}'", true);
                pn.Tag = p;

                var props = new RadTreeNode("Properties", Resources.Property, true);
                props.Tag = new PropertiesView();
                pn.Nodes.Add(props);

                pn.Expanded = p.Expandet;

                foreach (var f in p.Files)
                {
                    var n = new RadTreeNode(f.Src);
                    n.Tag = f;

                   // TODO: Add icon for file

                    pn.Nodes.Add(n);
                }

                ret.Nodes.Add(pn);
            }

            return ret;
        }
    }
}