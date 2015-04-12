using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerCommonLib
{
    /// <summary>
    /// This interface defines methods of BugTracker client.
    /// Defined methods are called by BugTracker server.
    /// </summary>
    public interface IBugTrackerClient
    {
        /// <summary>
        /// This method is used to get user list from BugTracker server.
        /// It is called by server once after user logged in to server.
        /// </summary>
        /// <param name="users">All online user informations</param>
        void GetUserList(UserInfo[] users);

        /// <summary>
        /// This method is called from BugTracker server to inform that a message
        /// is sent to everybody publicly.
        /// </summary>
        /// <param name="username">Username of sender</param>
        /// <param name="message">Message</param>
        void OnMessageToEverybody(string username, BugTrackerMessage message);

        /// <summary>
        /// This method is called from BugTracker server to inform that a new user
        /// joined to the server.
        /// </summary>
        /// <param name="userInfo">Informations of new user</param>
        void OnUserLogin(UserInfo userInfo);

        /// <summary>
        /// This method is called from chat server to inform that an existing user
        /// has left the server.
        /// </summary>
        /// <param name="username">Informations of new user</param>
        void OnUserLogout(string username);
    }
}
