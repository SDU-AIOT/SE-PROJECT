using Hik.Communication.ScsServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerCommonLib
{
    /// <summary>
    /// This interface defines BugTracker Service Contract.
    /// It is used by clients to interact with BugTracker Server.
    /// </summary>
    [ScsService(Version = "1.0.0.0")]
    public interface IBugTrackerService
    {
        /// <summary>
        /// Used to login to BugTracker service.
        /// </summary>
        /// <param name="userInfo">User informations</param>
        bool Login(UserInfo userInfo);

        /// <summary>
        /// Sends a public message to everyone.
        /// </summary>
        /// <param name="message">Message to be sent</param>
        void SendMessageToEverybody(BugTrackerMessage message);

        /// <summary>
        /// Used to logout from BugTracker service.
        /// Client may not call this method while logging out (in an application crash situation),
        /// it will also be logged out automatically when connection fails between
        /// client and server.
        /// </summary>
        void Logout();
    }
}
