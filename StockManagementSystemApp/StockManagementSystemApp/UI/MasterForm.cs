using StockManagementSystemApp.UI;
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
            userLabel.Text = "User Name - " + LoginForm.UserName;
            passwordLabel.Text = LoginForm.Password;
        }

        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm();
            itemForm.Show();
        }

        private void categorySetupToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            categorySetupForm category = new categorySetupForm();
            category.Show();
        }
        
        private void companySetupToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            companySetupForm company = new companySetupForm();
            company.Show();
        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockInForm stockInForm = new StockInForm();
            stockInForm.Show();
        }

        private void stockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stockOutForm form = new stockOutForm();
            form.Show();
        }

        private void searchViewSummarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchAndViewItemsSummaryForm search = new searchAndViewItemsSummaryForm();
            search.Show();
        }

        private void viewBetweenTwoDatesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewBetweenTwoDatesReportForm view = new viewBetweenTwoDatesReportForm();
            view.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aboutForm about = new aboutForm();
            about.Show();
        }
    }
}