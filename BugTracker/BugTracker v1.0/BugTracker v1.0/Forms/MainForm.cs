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
    public partial class MainForm : Form, IBugProcessView
    {
        private IScsServiceClient<IBugTrackerService> client;
        private UserInfo userInfo;
        private List<UserInfo> usersList;
        private string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Isco\Documents\SE-PROJECT\BugTracker\BugTracker v1.0\BugTracker v1.0 (Server)\BugTrackerDB.mdf';Integrated Security=True;Connect Timeout=30";

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            usersList = client.ServiceProxy.GetUsersList();
            /*foreach (UserInfo user in usersList)
            {
                Program.InvokeIfRequired(usersListBox, () =>
                    {
                        usersListBox.Items.Add(user.Name + " " + user.Surname);
                    });
            }*/
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
            /*
            Thread loadUsersThread = new Thread(LoadUsers);
            loadUsersThread.Start();
             */
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bugTrackerDBDataSet.Issue_with_projectName". При необходимости она может быть перемещена или удалена.
            this.issue_with_projectNameTableAdapter.Fill(this.bugTrackerDBDataSet.Issue_with_projectName);

            this.projectsTableAdapter.Fill(this.bugTrackerDBDataSet.Projects);

            // TODO: данная строка кода позволяет загрузить данные в таблицу "bugTrackerDBDataSet.Users". При необходимости она может быть перемещена или удалена.
            try
            {
                this.usersTableAdapter.FillWithRankNameBy(this.bugTrackerDBDataSet.Users);
            }
            catch (Exception)
            {
                
            }

        }

        private void fillProjectsData() 
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT name, description FROM Projects", con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //projectsListBox.Items.Clear();
                    
                    while (reader.Read())
                    {
                        ProjectItem item = new ProjectItem();
                        item.Name = reader["name"].ToString();
                        item.Description = reader["description"].ToString();
                        //projectsListView.Items.Add(item.Name).SubItems.Add(item.Description);
                    }
                }
                con.Close();
            }
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

        private void addProject_Click(object sender, EventArgs e)
        {
            EditProjectForm form = new EditProjectForm();
            form.client = client;
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Successfull :)");
                BugTrackerMessage message = new BugTrackerMessage("hello");
                message.MessageType = BugTrackerMessage.NEW_PROJECT;
                client.ServiceProxy.SendMessageToEverybody(message);
            }
        }

        private void issuesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.issuesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bugTrackerDBDataSet);

        }

        private void issuesBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.issuesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bugTrackerDBDataSet);

        }



        public void OnMessageReceived(string username, BugTrackerMessage message)
        {
            MessageBox.Show("new message");
            if (message.MessageType == BugTrackerMessage.NEW_ISSUE)
            {
                MessageBox.Show("New issue");
            }
            else if (message.MessageType == BugTrackerMessage.NEW_PROJECT)
            {
                MessageBox.Show("New project");
            }
            else if (message.MessageType == BugTrackerMessage.NEW_USER)
            {
                // TODO
            }
        }

        private void issuesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addIssue_Click(object sender, EventArgs e)
        {
            EditIssueForm form = new EditIssueForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPage();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.R || e.KeyCode == Keys.Z))
            {
                LoadPage();
            }
        }
    }
}
