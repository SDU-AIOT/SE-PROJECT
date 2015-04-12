using BugTrackerCommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker_v1._0
{
    public interface IBugController
    {
        /// <summary>
        /// Connects to the server.
        /// It automatically Logins to server if connection success.
        /// </summary>
        void Connect();

        /// <summary>
        /// Disconnects from server if it is connected.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Sends a public message to everyone.
        /// It will be seen all users.
        /// </summary>
        /// <param name="message">Message to be sent</param>
        void SendMessageToEveryone(BugTrackerMessage message);

    }
}
