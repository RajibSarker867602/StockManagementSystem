using StockManagementSystem.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystemApp.UI
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            userLabel.Text = "";
            passwordLabel.Text = "";
            userLabel.Text = "User Name- " + LoginForm.UserName;
            passwordLabel.Text = LoginForm.Password;
        }

        private void companySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            companySetupForm company = new companySetupForm();
            company.Show();
        }
    }
}
