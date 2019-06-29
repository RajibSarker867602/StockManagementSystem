using StockManagementSystem.Manager;
using StockManagementSystem.Models;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        User user = new User();
        UserManager _userManager = new UserManager();
        public static string UserName;
        public static string Password;

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (userNameTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter user name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    userNameTextBox.Clear();
                    userNameTextBox.Focus();
                    return;
                }
                if (passwordTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passwordTextBox.Clear();
                    passwordTextBox.Focus();
                    return;
                }
                user.UserName = userNameTextBox.Text;
                user.Password = passwordTextBox.Text;
                int isExist = _userManager.IsExistUser(user);
                if (isExist > 0)
                {
                    MasterForm masterForm = new MasterForm();
                    UserName = userNameTextBox.Text;
                    Password = passwordTextBox.Text;
                    this.Hide();
                    masterForm.Show();

                }
                else
                {
                    MessageBox.Show("User name or password does not match!", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    userNameTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
