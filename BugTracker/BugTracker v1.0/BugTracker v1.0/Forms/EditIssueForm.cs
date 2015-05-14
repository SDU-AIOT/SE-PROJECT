using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugTracker_v1._0.Forms
{
    public partial class EditIssueForm : Form
    {
        public EditIssueForm()
        {
            InitializeComponent();
        }

        private void EditIssueForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bugTrackerDBDataSet.Projects". При необходимости она может быть перемещена или удалена.
            this.projectsTableAdapter.Fill(this.bugTrackerDBDataSet.Projects);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bugTrackerDBDataSet.Issue_types". При необходимости она может быть перемещена или удалена.
            this.issue_typesTableAdapter.Fill(this.bugTrackerDBDataSet.Issue_types);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bugTrackerDBDataSet.Project_members". При необходимости она может быть перемещена или удалена.
            this.project_membersTableAdapter.Fill(this.bugTrackerDBDataSet.Project_members);

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Isco\Documents\SE-PROJECT\BugTracker\BugTracker v1.0\BugTracker v1.0 (Server)\BugTrackerDB.mdf';Integrated Security=True;Connect Timeout=30";
            using(SqlConnection con=new SqlConnection(connectionString))
            {
                string saveStaff = "INSERT INTO issues (name, description, due_date, assignee_id, project_id, type_id)" 
                    + " VALUES (@name,@description,@dueDate,@assigneeId,@projectId,@typeId)";

                using(SqlCommand querySaveStaff = new SqlCommand(saveStaff, con))
                {
                    querySaveStaff.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = issueName.Text;
                    querySaveStaff.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = issueDescription.Text;
                    querySaveStaff.Parameters.Add("@dueDate", SqlDbType.Date).Value = dueDate.Value.ToString("dd.MM.yyyy");
                    querySaveStaff.Parameters.Add("@assigneeId", SqlDbType.Int).Value = assigneeComboBox.SelectedValue;
                    querySaveStaff.Parameters.Add("@projectId", SqlDbType.Int).Value = projectComboBox.SelectedValue;
                    querySaveStaff.Parameters.Add("@typeId", SqlDbType.Int).Value = typeComboBox.SelectedValue;
                     
                    con.Open();
                    querySaveStaff.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
