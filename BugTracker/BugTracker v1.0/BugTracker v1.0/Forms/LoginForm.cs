using BugTrackerCommonLib;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using Hik.Communication.ScsServices.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugTracker_v1._0.Forms
{
    public partial class LoginForm : Form
    {
        public IScsServiceClient<IBugTrackerService> client;
        public UserInfo userInfo;
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            client = ScsServiceClientBuilder.CreateClient<IBugTrackerService>(new ScsTcpEndPoint("127.0.0.1", 10048));
            client.Connect();
            userInfo = new UserInfo();
            userInfo.Username = usernameField.Text;
            userInfo.Password = passwordField.Text;
            if (client.ServiceProxy.Login(userInfo))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else 
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

    }
}
