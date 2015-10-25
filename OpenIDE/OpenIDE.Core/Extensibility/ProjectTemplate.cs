using System;
using System.Drawing;

namespace OpenIDE.Core.Extensibility
{
    public class ProjectTemplate
    {
        public string Name { get; set; }
        public Image Icon { get; set; }
        public Guid ProjectID { get; set; }
        public string Extension { get; set; }

        public ProjectTemplate()
        {
            Name = "";
        }
    }
}