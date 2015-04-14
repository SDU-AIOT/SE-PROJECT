using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerCommonLib.Arguments
{
    /// <summary>
    /// Represents a BugTracker projects.
    /// This object particularly used for managing projects.
    /// </summary>
    [Serializable]
    public class ProjectInfo
    {
        private long id;
        private string name, description;

        /// <summary>
        /// Id of the project.
        /// </summary>
        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        /// <summary>
        /// Name of the Project
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        /// <summary>
        /// Description of the project
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
    }
}
