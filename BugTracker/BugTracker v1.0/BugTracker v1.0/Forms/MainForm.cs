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
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPage();
            } 
            else
            {
                Environment.Exit(0);
            }
        }

        private void LoadPage()
        {
            throw new NotImplementedException();
        }
    }
}
