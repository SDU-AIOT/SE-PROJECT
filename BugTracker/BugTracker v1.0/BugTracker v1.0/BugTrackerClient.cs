using BugTrackerCommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker_v1._0.Forms;

namespace BugTracker_v1._0
{
    class BugTrackerClient : IBugTrackerClient
    {
        private readonly IBugProcessView _mainForm;
        /// <summary>
        /// Creates a new BugTrackerClient.
        /// </summary>
        public BugTrackerClient(IBugProcessView mainForm) 
        {
            _mainForm = mainForm;
        }

        public void GetUserList(UserInfo[] users)
        {
            
        }

        /// <summary>
        /// This method is called from chat server to inform that a message
        /// is sent to chat room publicly.
        /// </summary>
        /// <param name="username">Username of sender</param>
        /// <param name="message">Message text</param>
        public void OnMessageToEverybody(string username, BugTrackerMessage message)
        {
            _mainForm.OnMessageReceived(username, message);
        }

        public void OnUserLogin(UserInfo userInfo)
        {

        }

        public void OnUserLogout(string username)
        {

        }
    }
}
