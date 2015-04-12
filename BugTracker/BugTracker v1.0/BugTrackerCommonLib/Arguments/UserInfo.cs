using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugTrackerCommonLib
{
    /// <summary>
    /// Represents a BugTracker user.
    /// This object particularly used in Login of a user.
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        private string username, password;

        /// <summary>
        /// Username of the user.
        /// </summary>
        public string Username { 
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        /// <summary>
        /// Password of the user.
        /// </summary>
        public string Password {
            get
            {
                return password;
            }
            set 
            {
                password = value; 
            }
        }

        /// <summary>
        /// Bytes of avatar of user.
        /// </summary>
        public byte[] AvatarBytes { get; set; }

    }
}
