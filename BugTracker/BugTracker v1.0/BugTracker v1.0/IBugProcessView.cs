using BugTrackerCommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker_v1._0
{
    interface IBugProcessView
    {
        /// <summary>
        /// This method is called when a message is sent to everybody.
        /// </summary>
        /// <param name="username">Username of sender</param>
        /// <param name="message">Message</param>
        void OnMessageReceived(string username, BugTrackerMessage message);

    }
}
