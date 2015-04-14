using BugTrackerCommonLib.Arguments;
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
        /// Add user to Database.
        /// </summary>
        /// <param name="addUserToDatabase">Add User to Database</param>
        bool AddUserToDatabase(UserInfo userInfo);

        /// <summary>
        /// Get User Information
        /// </summary>
        /// <param name="username">User's username</param>
        UserInfo GetUserInfo(string username);

        /// <summary>
        /// Get Users List
        /// </summary>      
        List<UserInfo> GetUsersList();

        /// <summary>
        /// Add Project to Database.
        /// </summary>
        void AddProjectToDatabase(ProjectInfo projectInfo, List<long> memberIds);

        /// <summary>
        /// Get List of Projects.
        /// </summary>
        List<ProjectInfo> GetProjectList();

        /// <summary>
        /// Add members to Project Members.
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <param name="memberIds">Member Ids</param>
        void AddMembersToProject(long projectId, List<long> memberIds);

        /// <summary>
        /// Used to logout from BugTracker service.
        /// Client may not call this method while logging out (in an application crash situation),
        /// it will also be logged out automatically when connection fails between
        /// client and server.
        /// </summary>
        void Logout();
    }
}
