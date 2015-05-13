namespace BugTracker_v1._0.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.thumbBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.addProject = new System.Windows.Forms.Button();
            this.addUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bugTrackerDBDataSet = new BugTracker_v1._0.BugTrackerDBDataSet();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager = new BugTracker_v1._0.BugTrackerDBDataSetTableAdapters.TableAdapterManager();
            this.usersTableAdapter = new BugTracker_v1._0.BugTrackerDBDataSetTableAdapters.UsersTableAdapter();
            this.issuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.issuesTableAdapter = new BugTracker_v1._0.BugTrackerDBDataSetTableAdapters.IssuesTableAdapter();
            this.issuesListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.thumbBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bugTrackerDBDataSet)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // thumbBox
            // 
            this.thumbBox.Image = global::BugTracker_v1._0.Properties.Resources.Koala;
            this.thumbBox.Location = new System.Drawing.Point(662, 3);
            this.thumbBox.Name = "thumbBox";
            this.thumbBox.Size = new System.Drawing.Size(48, 48);
            this.thumbBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.thumbBox.TabIndex = 0;
            this.thumbBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(716, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(36, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Vasya";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.usersListBox);
            this.panel1.Controls.Add(this.addProject);
            this.panel1.Controls.Add(this.addUser);
            this.panel1.Location = new System.Drawing.Point(675, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 276);
            this.panel1.TabIndex = 2;
            // 
            // usersListBox
            // 
            this.usersListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.ItemHeight = 20;
            this.usersListBox.Location = new System.Drawing.Point(3, 75);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(642, 244);
            this.usersListBox.TabIndex = 3;
            // 
            // addProject
            // 
            this.addProject.Location = new System.Drawing.Point(26, 46);
            this.addProject.Name = "addProject";
            this.addProject.Size = new System.Drawing.Size(95, 23);
            this.addProject.TabIndex = 1;
            this.addProject.Text = "New project...";
            this.addProject.UseVisualStyleBackColor = true;
            this.addProject.Click += new System.EventHandler(this.addProject_Click);
            // 
            // addUser
            // 
            this.addUser.Location = new System.Drawing.Point(26, 17);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(95, 23);
            this.addUser.TabIndex = 0;
            this.addUser.Text = "New user...";
            this.addUser.UseVisualStyleBackColor = true;
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "All users:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.thumbBox);
            this.panel2.Controls.Add(this.nameLabel);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(13, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(807, 66);
            this.panel2.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(656, 278);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.issuesListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(648, 252);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Issues";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bugTrackerDBDataSet
            // 
            this.bugTrackerDBDataSet.DataSetName = "BugTrackerDBDataSet";
            this.bugTrackerDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.usersDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(648, 252);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Users";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // usersDataGridView
            // 
            this.usersDataGridView.AutoGenerateColumns = false;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.usersDataGridView.DataSource = this.usersBindingSource;
            this.usersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersDataGridView.Location = new System.Drawing.Point(3, 3);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.Size = new System.Drawing.Size(642, 246);
            this.usersDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "username";
            this.dataGridViewTextBoxColumn2.HeaderText = "username";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn3.HeaderText = "name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "surname";
            this.dataGridViewTextBoxColumn4.HeaderText = "surname";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "rank";
            this.dataGridViewTextBoxColumn5.HeaderText = "rank";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.bugTrackerDBDataSet;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CommentsTableAdapter = null;
            this.tableAdapterManager.Issue_typesTableAdapter = null;
            this.tableAdapterManager.Project_membersTableAdapter = null;
            this.tableAdapterManager.ProjectsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = BugTracker_v1._0.BugTrackerDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = this.usersTableAdapter;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // issuesBindingSource
            // 
            this.issuesBindingSource.DataMember = "Issues";
            this.issuesBindingSource.DataSource = this.bugTrackerDBDataSet;
            // 
            // issuesTableAdapter
            // 
            this.issuesTableAdapter.ClearBeforeFill = true;
            // 
            // issuesListBox
            // 
            this.issuesListBox.DataSource = this.issuesBindingSource;
            this.issuesListBox.DisplayMember = "name";
            this.issuesListBox.FormattingEnabled = true;
            this.issuesListBox.Location = new System.Drawing.Point(6, 3);
            this.issuesListBox.Name = "issuesListBox";
            this.issuesListBox.Size = new System.Drawing.Size(639, 238);
            this.issuesListBox.TabIndex = 0;
            this.issuesListBox.ValueMember = "id";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 372);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "BugTracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thumbBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bugTrackerDBDataSet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addUser;
        private System.Windows.Forms.Button addProject;
        private System.Windows.Forms.ListBox usersListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private BugTrackerDBDataSet bugTrackerDBDataSet;
        private BugTrackerDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private BugTrackerDBDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private System.Windows.Forms.DataGridView usersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource issuesBindingSource;
        private BugTrackerDBDataSetTableAdapters.IssuesTableAdapter issuesTableAdapter;
        private System.Windows.Forms.ListBox issuesListBox;
    }
}