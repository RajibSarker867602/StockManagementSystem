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
    public partial class ItemForm : Form
    {

        private ItemManager _itemManager;
        private Item item;
        UserManager _userManager = new UserManager();
        public ItemForm()
        {
            InitializeComponent();
            _itemManager = new ItemManager();
            item = new Item();
        }

        private void saveItemButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    if (saveItemButton.Text.Equals("Save"))
                    {
                        item.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
                        item.CompanyId = Convert.ToInt32(companyComboBox.SelectedValue);
                        item.ItemName = itemNameTextBox.Text;
                        item.ReorderLevel = Convert.ToInt32(reorderTextBox.Text);
                        item.UserId = _userManager.GetUserId(LoginForm.UserName, LoginForm.Password);
                        item.CreatedDate = DateTime.Now;
                        int isExecuted;
                        isExecuted = _itemManager.InsertItem(item);
                        if (isExecuted > 0)
                        {
                            messageLabel.Text = "Item name saved successfully..";

                        }
                        else
                        {
                            messageLabel.Text = "Not Save";
                        }
                    }

                    else
                    {
                        int isExecuted = 0;
                        isExecuted = _itemManager.UpdateGridviewRow(item);
                        if (isExecuted > 0)
                        {
                            messageLabel.Text = "Updated Successfully";
                        }
                        else
                        {
                            messageLabel.Text = "Update Failed!";
                        }
                        saveItemButton.Text = "Save";
                    }
                    reorderTextBox.Clear();
                    itemNameTextBox.Clear();
                    categoryComboBox.Text = "Please Select Category";
                    companyComboBox.Text = "Please Select Company";
                }
                itemDataGridView.DataSource = _itemManager.ShowItemsInDatagridview();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void ItemForm_Load(object sender, EventArgs e)
        {

            categoryComboBox.DataSource = _itemManager.GetCategoriesInCategoryCombobox();
            companyComboBox.DataSource = _itemManager.GetCompanysInCompanyCombobox();
            itemDataGridView.DataSource = _itemManager.ShowItemsInDatagridview();
            categoryComboBox.Text = "Please Select Category";
            companyComboBox.Text = "Please Select Company";
            reorderTextBox.Text = "0";
        }
        public bool Validation()
        {

            if (categoryComboBox.Text == "Please Select Category")
            {

                messageLabel.Text = "Select Category First!";
                return false;

            }
            if (companyComboBox.Text == "Please Select Company")
            {
                messageLabel.Text = "Select Company First!";
                return false;
            }

            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                messageLabel.Text = "Item Field can not be Empty!";
                return false;
            }
            item.ItemName = itemNameTextBox.Text;
            bool IsExistName = _itemManager.IsExistName(item);
            if (_itemManager.IsExistName(item))
            {
                messageLabel.Text = "Item name is already exist!";
                return false;
            }
            if (String.IsNullOrEmpty(reorderTextBox.Text))
            {
                messageLabel.Text = "Reorder Field can not be Empty!";
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(reorderTextBox.Text, "[^0-9]"))
            {
                messageLabel.Text = "Enter Only Digits";
                return false;
            }
            return true;
        }

        private void itemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemDataGridView.CurrentRow.Selected = true;
            itemNameTextBox.Text = itemDataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
            item.Id = Convert.ToInt32(itemDataGridView.Rows[e.RowIndex].Cells["SL"].FormattedValue);
            categoryComboBox.Text = itemDataGridView.Rows[e.RowIndex].Cells["Category"].FormattedValue.ToString();
            companyComboBox.Text = itemDataGridView.Rows[e.RowIndex].Cells["Company"].FormattedValue.ToString();
            reorderTextBox.Text = itemDataGridView.Rows[e.RowIndex].Cells["ReOrderLevel"].FormattedValue.ToString();
            saveItemButton.Text = "Update";
        }
    }

}