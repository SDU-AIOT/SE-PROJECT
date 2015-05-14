using BugTrackerCommonLib;
using BugTrackerCommonLib.Arguments;
using Hik.Communication.ScsServices.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            if (projectName.Text.Length > 0 && projectDescription.Text.Length > 0 
                && assigneesCheckListBox.CheckedItems.Count > 0)    
            {
                /*
                List<long> memberIds = new List<long>();
                foreach (CheckItem item in assigneesCheckListBox.CheckedItems)
                {
                    memberIds.Add(item.id);
                }
                ProjectInfo projectInfo = new ProjectInfo();
                projectInfo.Name = projectName.Text;
                projectInfo.Description = projectDescription.Text;
                //client.ServiceProxy.AddProjectToDatabase(projectInfo, memberIds);
                this.DialogResult = DialogResult.OK;
                this.Close();
                 * */

                string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Isco\Documents\SE-PROJECT\BugTracker\BugTracker v1.0\BugTracker v1.0 (Server)\BugTrackerDB.mdf';Integrated Security=True;Connect Timeout=30";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string saveStaff = "INSERT INTO Projects (name, description)"
                        + " VALUES (@name,@description)";
                    int projectId = 1;

                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff, con))
                    {
                        querySaveStaff.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = projectName.Text;
                        querySaveStaff.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = projectDescription.Text;

                        con.Open();
                        querySaveStaff.ExecuteNonQuery();
                        con.Close();
                    }

                    saveStaff = "INSERT INTO Project_members (user_id, project_id)"
                        + " VALUES (@userId,@projectId)";

                    con.Open();
                    foreach (var item in assigneesCheckListBox.CheckedItems)
                    {
                        using (SqlCommand querySaveStaff = new SqlCommand(saveStaff, con))
                        {
                            querySaveStaff.Parameters.Add("@userId", SqlDbType.Int).Value = ((CheckItem)item).id;
                            querySaveStaff.Parameters.Add("@projectId", SqlDbType.Int).Value = projectId;

                            querySaveStaff.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
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
