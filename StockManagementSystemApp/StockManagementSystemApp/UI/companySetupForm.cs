using StockManagementSystemApp.Manager;
using StockManagementSystemApp.Models;
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
    public partial class companySetupForm : Form
    {
        public companySetupForm()
        {
            InitializeComponent();
        }
        Company company = new Company();
        CompanyManager _companyManager = new CompanyManager();
        UserManager userManager = new UserManager();
        List<Company> companies = new List<Company>();

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFormValid())
                {
                    if (SaveButton.Text == "&Save")
                    {
                        company.CompanyName = companyNameTextBox.Text;
                        company.UserId = userManager.GetUserId(LoginForm.UserName, LoginForm.Password);
                        company.CreatedDate = DateTime.Now;

                        if (_companyManager.IsExistCompany(company))
                        {
                            MessageBox.Show("Company name '" + companyNameTextBox.Text + "' already exist!", "Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            companyNameTextBox.Focus();
                            return;
                        }
                        string message = _companyManager.SaveCompany(company);
                        if (message == "Company Saved Successful.")
                        {
                            MessageBox.Show(message, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            companies = _companyManager.GetCompaies();
                            BindCompanysListGridView(companies);
                            companyNameTextBox.Clear();
                        }
                        else
                        {
                            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (SaveButton.Text == "Update")
                {
                    if (IsFormValid())
                    {
                        company.Id = Convert.ToInt32(idLabel.Text);
                        company.CompanyName = companyNameTextBox.Text;
                        company.UserId = userManager.GetUserId(LoginForm.UserName, LoginForm.Password);
                        company.CreatedDate = DateTime.Now;

                        if (_companyManager.IsExistCompany(company))
                        {
                            MessageBox.Show("Company name '" + companyNameTextBox.Text + "' already exist!", "Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            companyNameTextBox.Focus();
                            return;
                        }
                        string message = _companyManager.UpdateCompany(company);
                        if (message == "Company Update Successful.")
                        {
                            MessageBox.Show(message, "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            companies = _companyManager.GetCompaies();
                            BindCompanysListGridView(companies);
                            companyNameTextBox.Clear();
                            SaveButton.Text = "&Save";
                            SaveButton.BackColor = Color.Indigo;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindCompanysListGridView(List<Company> companies)
        {
            try
            {
                int serial = 0;
                companysListGirdView.Rows.Clear();
                foreach (var company in companies)
                {
                    serial++;
                    companysListGirdView.Rows.Add(serial, company.CompanyName, company.Id);
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsFormValid()
        {
            if (companyNameTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter company name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyNameTextBox.Focus();
                companyNameTextBox.Clear();
                return false;
            }
            return true;
        }

        private void companysListGirdView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = companysListGirdView.SelectedRows[0];
                companyNameTextBox.Text = row.Cells[1].Value.ToString();
                idLabel.Text = row.Cells[2].Value.ToString();
                SaveButton.Text = "Update";
                SaveButton.BackColor = Color.Magenta;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void companySetupForm_Load(object sender, EventArgs e)
        {
            try
            {
                companies = _companyManager.GetCompaies();
                BindCompanysListGridView(companies);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
