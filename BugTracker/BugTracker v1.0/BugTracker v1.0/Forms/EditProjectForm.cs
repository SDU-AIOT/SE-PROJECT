using BugTrackerCommonLib;
using Hik.Communication.ScsServices.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugTracker_v1._0.Forms
{
    public partial class EditProjectForm : Form
    {
        public IScsServiceClient<IBugTrackerService> client;
        public List<UserInfo> users;

        public EditProjectForm()
        {
            InitializeComponent();
            Thread loadUsersThread = new Thread(LoadUsers);
            loadUsersThread.Start();
        }

        private void LoadUsers()
        {
            users = client.ServiceProxy.GetUsersList();
            Program.InvokeIfRequired(assigneesCheckListBox, ()=>
            {
                for (int i = 0; i < users.Count; i++)
                assigneesCheckListBox.Items.Add(new CheckItem(users[i].Name + " " + users[i].Surname, users[i].Id));
            });
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (projectName.Text.Length == 0 || projectDescription.Text.Length == 0 
                || assigneesCheckListBox.CheckedItems.Count == 0)
            {
                List<long> memberIds = new List<long>();
                foreach (CheckItem item in assigneesCheckListBox.CheckedItems)
                {
                    memberIds.Add(item.id);
                }
                ProjectInfo projectInfo = new ProjectInfo();
                projectInfo.Name = projectName.Text;
                projectInfo.Description = projectDescription.Text;
                client.ServiceProxy.AddProjectToDatabase(projectInfo, memberIds);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private class CheckItem : Object
        {
            string name;
            public long id;
            public CheckItem(string name, long id)
            {
                this.name = name;
                this.id = id;
            }
            public override string ToString()
            {
                return name;
            }
        }
    }
}
