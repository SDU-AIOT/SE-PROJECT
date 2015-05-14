using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugTracker_v1._0.Forms
{
    class ProjectItem
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Description);
        }
    }
}
