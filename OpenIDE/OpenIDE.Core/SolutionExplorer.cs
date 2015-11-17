using OpenIDE.Core.ProjectSystem;
using OpenIDE.Core.Properties;
using OpenIDE.Core.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using Telerik.WinControls.UI;

namespace OpenIDE.Core
{
    public class SolutionExplorer
    {
        public static Dictionary<Guid, Image> Icons = new Dictionary<Guid, Image>();

        public static RadTreeNode Build(Project proj, RadContextMenu projectContextMenu, RadContextMenu fileContextMenu)
        {
            var pn = new RadTreeNode(LanguageManager._("Project") + $" '{proj.Name}'", true);
            pn.Tag = proj;
            pn.ContextMenu = projectContextMenu;

            var props = new RadTreeNode(LanguageManager._("Properties"), Resources.Property, true);
            props.Tag = new PropertiesView();
            pn.Nodes.Add(props);

            pn.Expanded = proj.Expandet;

            foreach (var f in proj.Files)
            {
                var n = Build(f, fileContextMenu);                

                pn.Nodes.Add(n);
            }

            return pn;
        }

        public static RadTreeNode Build(Solution sol, RadContextMenu solutionContextMenu, RadContextMenu projectContextMenu, RadContextMenu fileContextMenu)
        {
            var ret = new RadTreeNode(LanguageManager._("Solution") + $" '{sol.Name}'", true);
            ret.Tag = sol;
            ret.ContextMenu = solutionContextMenu;

            foreach (var p in sol.Projects)
            {
                var pn = Build(p, projectContextMenu, fileContextMenu);

                ret.Nodes.Add(pn);
            }

            return ret;
        }

        public static RadTreeNode Build(File sol, RadContextMenu fileContextMenu)
        {
            var n = new RadTreeNode(sol.Name);
            n.Tag = sol;
            n.ContextMenu = fileContextMenu;

            if (Icons.ContainsKey(sol.ID))
            {
                n.Image = Icons[sol.ID];
            }

            return n;
        }

        public static RadTreeNode Build(Project sol, RadContextMenu projectContextMenu)
        {
            var n = new RadTreeNode(sol.Name);
            n.Tag = sol;
            n.ContextMenu = projectContextMenu;

            if (Icons.ContainsKey(sol.Type))
            {
                n.Image = Icons[sol.Type];
            }

            return n;
        }

    }
}