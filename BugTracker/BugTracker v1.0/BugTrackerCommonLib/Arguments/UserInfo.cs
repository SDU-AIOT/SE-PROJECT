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
        private string username, password, surname, name;
        private int rank;
        private long id;

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
        /// Surname of the user.
        /// </summary>
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        /// <summary>
        /// Name of the user.
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
        /// Rank of the user.
        /// </summary>
        public int Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
            }
        }
        /// <summary>
        /// Rank of the user.
        /// </summary>
        public string RankName
        {
            get
            {
                switch (rank)
                {
                    case 1:
                        return "Administrator";
                    case 2:
                        return "Project Manager";
                    case 3:
                        return "Developer";
                    case 4:
                        return "Tester";
                    default:
                        return "";
                }
            }
            set { }
        }
        /// <summary>
        /// ID of the user;
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
        /// Bytes of avatar of user.
        /// </summary>
        public byte[] AvatarBytes { get; set; }

    }
}
