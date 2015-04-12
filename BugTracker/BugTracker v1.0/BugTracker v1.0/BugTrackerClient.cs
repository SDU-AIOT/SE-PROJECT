using BugTrackerCommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker_v1._0
{
    class BugTrackerClient : IBugTrackerClient
    {
        /// <summary>
        /// Creates a new BugTrackerClient.
        /// </summary>
        public BugTrackerClient() 
        {

        }

        public void GetUserList(UserInfo[] users)
        {
            foreach (var user in users)
            {

            }
        }

        /// <summary>
        /// This method is called from chat server to inform that a message
        /// is sent to chat room publicly.
        /// </summary>
        /// <param name="username">Username of sender</param>
        /// <param name="message">Message text</param>
        public void OnMessageToEverybody(string username, BugTrackerMessage message)
        {

        }

        public void OnUserLogin(UserInfo userInfo)
        {

        }

        public void OnUserLogout(string username)
        {

        }
    }
}
