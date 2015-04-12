using BugTrackerCommonLib;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
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
        private MainForm mainForm;

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
            var client = ScsServiceClientBuilder.CreateClient<IBugTrackerService>(new ScsTcpEndPoint("127.0.0.1", 10048));
            client.Connect();
            UserInfo userInfo = new UserInfo();
            userInfo.Username = "Isco";
            userInfo.Password = "123";
            if (client.ServiceProxy.Login(userInfo))
            {
                mainForm = new MainForm();
                mainForm.Show();
            }

        }

    }
}
