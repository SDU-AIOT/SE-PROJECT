using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Hik.Communication.ScsServices.Service;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using BugTrackerCommonLib;
namespace BugTracker_v1._0__Server_
{
    public partial class ServerForm : Form
    {
        IScsServiceApplication _serviceApplication;
        BugTrackerService _bugTrackerService;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void StartServer()
        {
            try
            {
                _serviceApplication = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(10048));
                _bugTrackerService = new BugTrackerService();
                _serviceApplication.AddService<IBugTrackerService, BugTrackerService>(_bugTrackerService);
                _bugTrackerService.UserListChanged += bugTracker_UserListChanged;
                _serviceApplication.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service can not be started. Exception detail: " + ex.Message);
                return;
            }
        }

        private void bugTracker_UserListChanged(object sender, EventArgs e)
        {
            Program.InvokeIfRequired(connectedUsersListBox, () =>
            {
                connectedUsersListBox.Items.Clear();
            });
            for (int i = 0; i < _bugTrackerService.UserList.Count; i++)
            {
                Program.InvokeIfRequired(connectedUsersListBox, () =>
                {
                    connectedUsersListBox.Items.Add(_bugTrackerService.UserList[i].Username);
                });
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            StartServer();
        }

        private void Server_Closing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            if (_serviceApplication == null)
            {
                return;
            }

            _serviceApplication.Stop();
        }
    }
}
