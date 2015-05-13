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
    public partial class MainForm : Form
    {
        private IScsServiceClient<IBugTrackerService> client;
        private UserInfo userInfo;
        private List<UserInfo> usersList;

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            usersList = client.ServiceProxy.GetUsersList();
            foreach (UserInfo user in usersList)
            {
                Program.InvokeIfRequired(usersListBox, () =>
                    {
                        usersListBox.Items.Add(user.Name + " " + user.Surname);
                    });
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bugTrackerDBDataSet.Issues". При необходимости она может быть перемещена или удалена.
            this.issuesTableAdapter.Fill(this.bugTrackerDBDataSet.Issues);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bugTrackerDBDataSet.Issues". При необходимости она может быть перемещена или удалена.
            this.issuesTableAdapter.Fill(this.bugTrackerDBDataSet.Issues);
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

            Thread loadUsersThread = new Thread(LoadUsers);
            loadUsersThread.Start();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bugTrackerDBDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.FillWithRankNameBy(this.bugTrackerDBDataSet.Users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bugTrackerDBDataSet.Issues". При необходимости она может быть перемещена или удалена.
            this.issuesTableAdapter.Fill(this.bugTrackerDBDataSet.Issues);

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

        internal void OnMessageReceived(BugTrackerMessage message)
        {
            int temp = 1;
            switch (temp)
            {
                case 1:
                    // 
                    break;
                case 2:
                    //TODO
                    break;
                case 3:
                    //TODO
                    break;
                default:
                    break;
            }
        }
    }
}
