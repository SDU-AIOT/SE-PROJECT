using BugTrackerCommonLib;
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
    public partial class EditUserForm : Form
    {
        public string username, name, surname, password;
        public int userType = 3;

        public UserInfo userInfo;
        public Hik.Communication.ScsServices.Client.IScsServiceClient<IBugTrackerService> client;

        public EditUserForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            userInfo = new UserInfo();
            userInfo.Username = usernameField.Text;
            userInfo.Name = nameField.Text;
            userInfo.Surname = surnameField.Text;
            userInfo.Password = passwordField.Text;
            userInfo.Rank = userTypeBox.SelectedIndex;

            if (client.ServiceProxy.AddUserToDatabase(userInfo))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("The username already exists");
            }
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
