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
            this.thumbBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.thumbBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // thumbBox
            // 
            this.thumbBox.Image = global::BugTracker_v1._0.Properties.Resources.Koala;
            this.thumbBox.Location = new System.Drawing.Point(701, 12);
            this.thumbBox.Name = "thumbBox";
            this.thumbBox.Size = new System.Drawing.Size(48, 48);
            this.thumbBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.thumbBox.TabIndex = 0;
            this.thumbBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(755, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(36, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Vasya";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addUser);
            this.panel1.Location = new System.Drawing.Point(675, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 276);
            this.panel1.TabIndex = 2;
            // 
            // addUser
            // 
            this.addUser.Location = new System.Drawing.Point(36, 16);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(75, 23);
            this.addUser.TabIndex = 0;
            this.addUser.Text = "New user...";
            this.addUser.UseVisualStyleBackColor = true;
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 372);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.thumbBox);
            this.Name = "MainForm";
            this.Text = "BugTracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thumbBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addUser;
    }
}