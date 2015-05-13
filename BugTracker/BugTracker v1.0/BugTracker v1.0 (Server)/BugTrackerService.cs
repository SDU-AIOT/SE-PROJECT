using BugTrackerCommonLib;
using Hik.Collections;
using Hik.Communication.ScsServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BugTrackerCommonLib.Arguments;
namespace BugTracker_v1._0__Server_
{
    class BugTrackerService : ScsService, IBugTrackerService
    {
        #region Events 

        /// <summary>
        /// This event is raised when online user list is changes.
        /// It is usually raised when a new user log in or a user log out.
        /// </summary
        public event EventHandler UserListChanged;
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a list of online users.
        /// </summary>
        public List<UserInfo> UserList
        {
            get
            {
                return (from client in _clients.GetAllItems()
                        select client.User).ToList();
            }
        }

        #endregion

        #region Private Fields

        /// <summary>
        /// List of all connected clients.
        /// </summary>
        private readonly ThreadSafeSortedList<long, BugTrackerClient> _clients;
        string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=\\psf\Home\Documents\Visual Studio 2013\Projects\SE-PROJECT\BugTracker\BugTracker v1.0\BugTracker v1.0 (Server)\BugTrackerDB.mdf;Integrated Security=True";
          
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public BugTrackerService()
        {
            _clients = new ThreadSafeSortedList<long, BugTrackerClient>();
        }

        #endregion

        #region IBugTracker methods

        /// <summary>
        /// Used to login to BugTracker service.
        /// </summary>
        /// <param name="userInfo">User informations</param>
        public bool Login(UserInfo userInfo)
        {
            //Check nick if it is being used by another user
            if (FindClientByNick(userInfo.Username) != null)
            {
                throw new UsernameInUseException("The username '" + userInfo.Username + "' is being used by another user. Please select another one.");
            }
            if (checkLogin(userInfo))
            {
                //Get a reference to the current client that is calling this method
                var client = CurrentClient;
                //Get a proxy object to call methods of client when needed
                var clientProxy = client.GetClientProxy<IBugTrackerClient>();

                //Create a BugTrackerClient and store it in a collection
                var bugTrackerClient = new BugTrackerClient(client, clientProxy, userInfo);
                _clients[client.ClientId] = bugTrackerClient;

                //Register to Disconnected event to know when user connection is closed
                client.Disconnected += Client_Disconnected;
                //Start a new task to send user list to new user and to inform
                //all users that a new user joined to room
                Task.Factory.StartNew(
                () =>
                {
                    OnUserListChanged();
                    SendUserListToClient(bugTrackerClient);
                    SendUserLoginInfoToAllClients(userInfo);
                });
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sends a public message to room.
        /// It will be seen all users in room.
        /// </summary>
        /// <param name="message">Message to be sent</param>
        public void SendMessageToEverybody(BugTrackerMessage message)
        {
            //Get BugTrackerClient object
            var senderClient = _clients[CurrentClient.ClientId];
            if (senderClient == null)
            {
                throw new ApplicationException("Can not send message before login.");
            }

            //Send message to all online users
            Task.Factory.StartNew(
                () =>
                {
                    foreach (var bugTrackerClient in _clients.GetAllItems())
                    {
                        try
                        {
                            bugTrackerClient.ClientProxy.OnMessageToEverybody(senderClient.User.Username, message);
                        }
                        catch
                        {

                        }
                    }
                });
        }

        /// <summary>
        /// Add user to Database.
        /// </summary>
        /// <param name="userInfo">User Info</param>
        public bool AddUserToDatabase(UserInfo userInfo)
        {
            if (!checkIfUsernameExists(userInfo))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(string.Format("INSERT INTO USERS (username,name,surname,rank,password) VALUES('{0}','{1}','{2}',{3},'{4}')", userInfo.Username, userInfo.Name, userInfo.Surname, userInfo.Rank, userInfo.Password), con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                    return true;
                }
            }
            return false;
        }
                    
        /// <summary>
        /// Get User Information
        /// </summary>
        /// <param name="getUserInfo">User Information</param>
        public UserInfo GetUserInfo(string username)
        {
            UserInfo userInfo = new UserInfo();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Users where username='" + username + "'", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userInfo.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        userInfo.Username = reader.GetString(reader.GetOrdinal("username"));
                        userInfo.Name = reader.GetString(reader.GetOrdinal("name"));
                        userInfo.Surname = reader.GetString(reader.GetOrdinal("surname"));
                        userInfo.Rank = reader.GetInt32(reader.GetOrdinal("rank"));
                        userInfo.Password = reader.GetString(reader.GetOrdinal("password"));
                    }
                }
                con.Close();
            }
            return userInfo;
        }
        /// <summary>
        /// Get Users List
        /// </summary>      
        public List<UserInfo> GetUsersList()
        {
            List<UserInfo> usersList = new List<UserInfo>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Users", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserInfo userInfo = new UserInfo();
                        userInfo.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        userInfo.Username = reader.GetString(reader.GetOrdinal("username"));
                        userInfo.Name = reader.GetString(reader.GetOrdinal("name"));
                        userInfo.Surname = reader.GetString(reader.GetOrdinal("surname"));
                        userInfo.Rank = reader.GetInt32(reader.GetOrdinal("rank"));
                        userInfo.Password = reader.GetString(reader.GetOrdinal("password"));
                        usersList.Add(userInfo);
                    }
                }
                con.Close();
            }
            return usersList;
        }
        /// <summary>
        /// Add Project to Database.
        /// </summary>
        public void AddProjectToDatabase(ProjectInfo projectInfo, List<long> memberIds)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(string.Format("INSERT INTO Projects (name,description) VALUES('{0}','{1}')", projectInfo.Name, projectInfo.Description), con))
                {
                    command.ExecuteNonQuery();
                }
                if (memberIds != null)
                {
                    using (SqlCommand command = new SqlCommand("SELECT max(id) FROM Projects", con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        AddMembersToProject(reader.GetInt32(0), memberIds);
                    }
                }
                con.Close();
            }
        }
        /// <summary>
        /// Get List of Projects.
        /// </summary>
        public List<ProjectInfo> GetProjectList()
        {
            List<ProjectInfo> projectList = new List<ProjectInfo>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Projects", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProjectInfo projectInfo = new ProjectInfo();
                        projectInfo.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        projectInfo.Name = reader.GetString(reader.GetOrdinal("name"));
                        projectInfo.Description = reader.GetString(reader.GetOrdinal("description"));
                        projectList.Add(projectInfo);
                }
                    }
                con.Close();
            }
            return projectList;
        }
        /// <summary>
        /// Add members to Project Members.
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <param name="memberIds">Member Ids</param>
        public void AddMembersToProject(long projectId, List<long> memberIds)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                for (int i = 0; i < memberIds.Count(); i++)
                {
                    using (SqlCommand command = new SqlCommand(string.Format("INSERT INTO Project_members (user_id,project_id) VALUES({0},{1})", memberIds.ElementAt(i), projectId), con))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }
        /// <summary>
        /// Used to logout from BugTracker service.
        /// Client may not call this method while logging out (in an application crash situation),
        /// it will also be logged out automatically when connection fails between client and server.
        /// </summary>
        public void Logout()
        {
            ClientLogout(CurrentClient.ClientId);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Handles Disconnected event of all clients.
        /// </summary>
        /// <param name="sender">Client object that is disconnected</param>
        /// <param name="e">Event arguments (not used in this event)</param>
        private void Client_Disconnected(object sender, EventArgs e)
        {
            //Get client object
            var client = (IScsServiceClient)sender;

            //Perform logout (so, if client did not call Logout method before close,
            //we do logout automatically.
            ClientLogout(client.ClientId);
        }

        /// <summary>
        /// This method is used to send list of all online users to a new joined user.
        /// </summary>
        /// <param name="client">New user that is joined to service</param>
        private void SendUserListToClient(BugTrackerClient client)
        {
            //Get all users except new user
            var userList = UserList.Where((user) => (user.Username != client.User.Username)).ToArray();

            //Do not send list if no user available (except the new user)
            if (userList.Length <= 0)
            {
                return;
            }

            client.ClientProxy.GetUserList(userList);
        }

        /// <summary>
        /// This method is called when a client Calls Logout method of service or a client
        /// connection fails.
        /// </summary>
        /// <param name="clientId">Unique Id of client that is logged out</param>
        private void ClientLogout(long clientId)
        {
            //Get client from client list, if not in list do not continue
            var client = _clients[clientId];
            if (client == null)
            {
                return;
            }

            //Remove client from online clients list
            _clients.Remove(client.Client.ClientId);

            //Unregister to Disconnected event (not needed really)
            client.Client.Disconnected -= Client_Disconnected;

            //Start a new task to inform all other users
            Task.Factory.StartNew(
                () =>
                {
                    OnUserListChanged();
                    SendUserLogoutInfoToAllClients(client.User.Username);
                });
        }

        /// <summary>
        /// This method is used to inform all online clients
        /// that a new user joined to room.
        /// </summary>
        /// <param name="userInfo">New joined user's informations</param>
        private void SendUserLoginInfoToAllClients(UserInfo userInfo)
        {
            foreach (var client in _clients.GetAllItems())
            {
                //Do not send informations to user that is logged in.
                if (client.User.Username == userInfo.Username)
                {
                    continue;
                }

                try
                {
                    client.ClientProxy.OnUserLogin(userInfo);
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// This method is used to inform all online clients
        /// that a user disconnected from BugTracker server.
        /// </summary>
        /// <param name="nick">Nick of disconnected user</param>
        private void SendUserLogoutInfoToAllClients(string nick)
        {
            foreach (var client in _clients.GetAllItems())
            {
                try
                {
                    client.ClientProxy.OnUserLogout(nick);
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Finds BugTrackerClient ojbect by given nick.
        /// </summary>
        /// <param name="nick">Nick to search</param>
        /// <returns>Found BugTrackerClient for that nick, or null if not found</returns>
        private BugTrackerClient FindClientByNick(string username)
        {
            return (from client in _clients.GetAllItems()
                    where client.User.Username == username
                    select client).FirstOrDefault();
        }
        /// <summary>
        /// Check For User in Database
        /// </summary>
        /// <param name="checkLogin">Check Login</param>
        /// <returns>Returns true if found, and false if not</returns>
        private bool checkLogin(UserInfo userInfo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Users where username='" + userInfo.Username + "'", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (userInfo.Password.Equals(reader.GetString(reader.GetOrdinal("password"))))
                        {
                            con.Close();
                            return true;
                        }
                    }
                }
                con.Close();
            }
            return false;
        }
        private bool checkIfUsernameExists(UserInfo userInfo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users where username='" + userInfo.Username + "'", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader.GetInt32(0) > 0)
                        {
                            con.Close();
                            return true;
                        }
                    }
                }
                con.Close();
            }
            return false;
        }

        #endregion

        #region Event raising methods

        /// <summary>
        /// Raises UserListChanged event.
        /// </summary>
        private void OnUserListChanged()
        {
            var handler = UserListChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Sub classes

        /// <summary>
        /// This class is used to store informations for a connected client.
        /// </summary>
        private sealed class BugTrackerClient
        {
            /// <summary>
            /// Scs client reference.
            /// </summary>
            public IScsServiceClient Client { get; private set; }

            /// <summary>
            /// Proxy object to call remote methods of BugTracker client.
            /// </summary>
            public IBugTrackerClient ClientProxy { get; private set; }

            /// <summary>
            /// User informations of client.
            /// </summary>
            public UserInfo User { get; private set; }

            /// <summary>
            /// Creates a new BugTrackerClient object.
            /// </summary>
            /// <param name="client">Scs client reference</param>
            /// <param name="clientProxy">Proxy object to call remote methods of BugTracker client</param>
            /// <param name="userInfo">User informations of client</param>
            public BugTrackerClient(IScsServiceClient client, IBugTrackerClient clientProxy, UserInfo userInfo)
            {
                Client = client;
                ClientProxy = clientProxy;
                User = userInfo;
            }
        }

        #endregion
    }
}
