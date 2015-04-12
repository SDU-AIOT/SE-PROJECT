using BugTrackerCommonLib;
using Hik.Communication.Scs.Communication;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using Hik.Communication.ScsServices.Communication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker_v1._0
{
    internal class BugController : IBugController
    {
        /// <summary>
        /// The object which handles remote method calls from server.
        /// It implements IBugTrackerClient contract.
        /// </summary>
        private BugTrackerClient _bugTrackerClient;

        /// <summary>
        /// This object is used to connect to SCS BugTracker Service as a client. 
        /// </summary>
        private IScsServiceClient<IBugTrackerService> _scsClient;


        #region IChatController implementation

        /// <summary>
        /// Connects to the server.
        /// It automatically Logins to server if connection success.
        /// </summary>
        public void Connect()
        {
            //Disconnect if currently connected
            Disconnect();

            //Create a ChatClient to handle remote method invocations by server
            _bugTrackerClient = new BugTrackerClient();

            //Create a SCS client to connect to SCS server
            _scsClient = ScsServiceClientBuilder.CreateClient<IBugTrackerService>(new ScsTcpEndPoint("localhost", 10048), _bugTrackerClient);

            //Register events of SCS client
            _scsClient.Connected += ScsClient_Connected;
            _scsClient.Disconnected += ScsClient_Disconnected;

            //Connect to the server
            _scsClient.Connect();
        }

        private void ScsClient_Disconnected(object sender, EventArgs e)
        {
            
        }

        private void ScsClient_Connected(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Disconnects from server if it is connected.
        /// </summary>
        public void Disconnect()
        {
            if (_scsClient != null && _scsClient.CommunicationState == CommunicationStates.Connected)
            {
                try
                {
                    _scsClient.Disconnect();
                }
                catch
                {

                }

                _scsClient = null;
            }
        }

        /// <summary>
        /// Sends a public message to room.
        /// It will be seen by all users in room.
        /// </summary>
        /// <param name="message">Message to be sent</param>
        public void SendMessageToEveryone(BugTrackerMessage message)
        {
            _scsClient.ServiceProxy.SendMessageToEverybody(message);
        }

        #endregion

    }
}
