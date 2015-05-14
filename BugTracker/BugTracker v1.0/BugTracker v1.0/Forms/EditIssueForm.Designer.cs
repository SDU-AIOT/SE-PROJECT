namespace BugTracker_v1._0.Forms
{
    partial class EditIssueForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.issueDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.issueName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.assigneeComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.projectComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bugTrackerDBDataSet = new BugTracker_v1._0.BugTrackerDBDataSet();
            this.projectmembersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.project_membersTableAdapter = new BugTracker_v1._0.BugTrackerDBDataSetTableAdapters.Project_membersTableAdapter();
            this.issuetypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.issue_typesTableAdapter = new BugTracker_v1._0.BugTrackerDBDataSetTableAdapters.Issue_typesTableAdapter();
            this.projectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectsTableAdapter = new BugTracker_v1._0.BugTrackerDBDataSetTableAdapters.ProjectsTableAdapter();
            this.dueDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.bugTrackerDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectmembersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuetypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Assignee:";
            // 
            // issueDescription
            // 
            this.issueDescription.Location = new System.Drawing.Point(91, 68);
            this.issueDescription.Name = "issueDescription";
            this.issueDescription.Size = new System.Drawing.Size(181, 93);
            this.issueDescription.TabIndex = 12;
            this.issueDescription.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Description:";
            // 
            // issueName
            // 
            this.issueName.Location = new System.Drawing.Point(91, 39);
            this.issueName.Name = "issueName";
            this.issueName.Size = new System.Drawing.Size(181, 20);
            this.issueName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Issue name:";
            // 
            // assigneeComboBox
            // 
            this.assigneeComboBox.DataSource = this.projectmembersBindingSource;
            this.assigneeComboBox.DisplayMember = "user_id";
            this.assigneeComboBox.FormattingEnabled = true;
            this.assigneeComboBox.Location = new System.Drawing.Point(92, 171);
            this.assigneeComboBox.Name = "assigneeComboBox";
            this.assigneeComboBox.Size = new System.Drawing.Size(178, 21);
            this.assigneeComboBox.TabIndex = 14;
            this.assigneeComboBox.ValueMember = "user_id";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DataSource = this.issuetypesBindingSource;
            this.typeComboBox.DisplayMember = "name";
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(91, 198);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(179, 21);
            this.typeComboBox.TabIndex = 16;
            this.typeComboBox.ValueMember = "id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Type:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(197, 289);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(116, 289);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // projectComboBox
            // 
            this.projectComboBox.DataSource = this.projectsBindingSource;
            this.projectComboBox.DisplayMember = "name";
            this.projectComboBox.FormattingEnabled = true;
            this.projectComboBox.Location = new System.Drawing.Point(92, 12);
            this.projectComboBox.Name = "projectComboBox";
            this.projectComboBox.Size = new System.Drawing.Size(179, 21);
            this.projectComboBox.TabIndex = 20;
            this.projectComboBox.ValueMember = "id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Project:";
            // 
            // bugTrackerDBDataSet
            // 
            this.bugTrackerDBDataSet.DataSetName = "BugTrackerDBDataSet";
            this.bugTrackerDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projectmembersBindingSource
            // 
            this.projectmembersBindingSource.DataMember = "Project_members";
            this.projectmembersBindingSource.DataSource = this.bugTrackerDBDataSet;
            // 
            // project_membersTableAdapter
            // 
            this.project_membersTableAdapter.ClearBeforeFill = true;
            // 
            // issuetypesBindingSource
            // 
            this.issuetypesBindingSource.DataMember = "Issue_types";
            this.issuetypesBindingSource.DataSource = this.bugTrackerDBDataSet;
            // 
            // issue_typesTableAdapter
            // 
            this.issue_typesTableAdapter.ClearBeforeFill = true;
            // 
            // projectsBindingSource
            // 
            this.projectsBindingSource.DataMember = "Projects";
            this.projectsBindingSource.DataSource = this.bugTrackerDBDataSet;
            // 
            // projectsTableAdapter
            // 
            this.projectsTableAdapter.ClearBeforeFill = true;
            // 
            // dueDate
            // 
            this.dueDate.CustomFormat = "dd.MM.yyy";
            this.dueDate.Location = new System.Drawing.Point(92, 226);
            this.dueDate.Name = "dueDate";
            this.dueDate.Size = new System.Drawing.Size(178, 20);
            this.dueDate.TabIndex = 21;
            // 
            // EditIssueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 324);
            this.Controls.Add(this.dueDate);
            this.Controls.Add(this.projectComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.assigneeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.issueDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.issueName);
            this.Controls.Add(this.label1);
            this.Name = "EditIssueForm";
            this.Text = "EditIssue";
            this.Load += new System.EventHandler(this.EditIssueForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bugTrackerDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectmembersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuetypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox issueDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox issueName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox assigneeComboBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox projectComboBox;
        private System.Windows.Forms.Label label5;
        private BugTrackerDBDataSet bugTrackerDBDataSet;
        private System.Windows.Forms.BindingSource projectmembersBindingSource;
        private BugTrackerDBDataSetTableAdapters.Project_membersTableAdapter project_membersTableAdapter;
        private System.Windows.Forms.BindingSource issuetypesBindingSource;
        private BugTrackerDBDataSetTableAdapters.Issue_typesTableAdapter issue_typesTableAdapter;
        private System.Windows.Forms.BindingSource projectsBindingSource;
        private BugTrackerDBDataSetTableAdapters.ProjectsTableAdapter projectsTableAdapter;
        private System.Windows.Forms.DateTimePicker dueDate;
    }
}