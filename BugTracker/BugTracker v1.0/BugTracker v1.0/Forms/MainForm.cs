using BugTrackerCommonLib;
using Hik.Communication.ScsServices.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugTracker_v1._0.Forms
{
    public partial class MainForm : Form
    {
        private IScsServiceClient<IBugTrackerService> client;
        private UserInfo userInfo;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                client = form.client;
                userInfo = form.userInfo;
                LoadPage();
            } 
            else
            {
                Environment.Exit(0);
            }
        }

        private void LoadPage()
        {
            nameLabel.Text = userInfo.Username;
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            EditUserForm form = new EditUserForm();
            form.client = client;
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Successfull :)");
            }
        }
    }
}
