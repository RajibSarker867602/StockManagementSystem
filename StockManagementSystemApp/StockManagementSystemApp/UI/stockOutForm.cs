using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystemApp.Manager;
using StockManagementSystemApp.Models;

namespace StockManagementSystemApp.UI
{
    public partial class stockOutForm : Form
    {
        public stockOutForm()
        {
            InitializeComponent();
        }
        Item item = new Item();
        ItemManager _itemManager = new ItemManager();
        StockInManager _stockInManager = new StockInManager();
        StockOutManager _stockOutManager = new StockOutManager();
        CategoryManager _categoryManager = new CategoryManager();
        CompanyManager _companyManager = new CompanyManager();
        UserManager _userManager = new UserManager();
        List<Item> items = new List<Item>();

        private void stockOutForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCompaniesComboBox();
                reorderLevelMessageLabel.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCompaniesComboBox()
        {
            try
            {
                List<Company> companies = _companyManager.GetCompaies();
                Company company = new Company();
                company.Id = 0;
                company.CompanyName = "--Select--";
                companies.Insert(0, company);
                companiesComboBox.DataSource = null;
                companiesComboBox.DataSource = companies;
                companiesComboBox.DisplayMember = "CompanyName";
                companiesComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void companiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (companiesComboBox.SelectedIndex > 0)
                {
                    Company company = new Company();
                    company.Id = Convert.ToInt32(companiesComboBox.SelectedValue);
                    List<Category> categories = _categoryManager.GetCategoriesByCompany(company);
                    if (categories.Count > 0)
                    {
                        Category category = new Category();
                        category.Id = 0;
                        category.CategoryName = "--Select--";
                        categories.Insert(0, category);
                        categoriesComboBox.DataSource = null;
                        categoriesComboBox.DataSource = categories;
                        categoriesComboBox.DisplayMember = "CategoryName";
                        categoriesComboBox.ValueMember = "Id";
                        reorderLevelMessageLabel.Text = "";
                    }
                    else
                    {
                        string data = "No Data Found!";
                        categoriesComboBox.DataSource = data;
                        reorderLevelMessageLabel.Text = "";
                    }
                }
                else
                {
                    categoriesComboBox.DataSource = null;
                    itemsComboBox.DataSource = null;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (categoriesComboBox.SelectedIndex > 0)
                {
                    int categoryId = Convert.ToInt32(categoriesComboBox.SelectedValue);
                    int companyId = Convert.ToInt32(companiesComboBox.SelectedValue);
                    List<Item> items = _itemManager.GetItemsByCategoryAndCompany(categoryId, companyId);
                    if (items.Count > 0)
                    {
                        Item item = new Item();
                        item.Id = 0;
                        item.ItemName = "--Select--";
                        items.Insert(0, item);
                        itemsComboBox.DataSource = null;
                        itemsComboBox.DataSource = items;
                        itemsComboBox.DisplayMember = "ItemName";
                        itemsComboBox.ValueMember = "Id";
                        reorderLevelMessageLabel.Text = "";
                    }
                    else
                    {
                        List<string> data = new List<string>();
                        data.Add("No Data Found!");
                        itemsComboBox.DataSource = data;
                        reorderLevelMessageLabel.Text = "";
                    }
                }
                else
                {
                    itemsComboBox.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (itemsComboBox.SelectedIndex > 0)
                {
                    item.Id = Convert.ToInt32(itemsComboBox.SelectedValue);
                    reorderLeveTextBox.Text = _itemManager.GetItemReorderLevel(item).ToString();
                    int stockInQuantity = Convert.ToInt32(_stockInManager.GetItemAvailableQuantity(item.Id));
                    int stockOutQuantity = Convert.ToInt32(_stockOutManager.GetItemStockOutQuantity(item.Id));
                    int availableQuantity = stockInQuantity - stockOutQuantity;
                    availableQuantityTextBox.Text = availableQuantity.ToString();
                    reorderLevelMessageLabel.Text = "";
                }
                else
                {
                    reorderLeveTextBox.Clear();
                    availableQuantityTextBox.Clear();
                    reorderLevelMessageLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFormValid())
                {
                    Item item = new Item();
                    int reOrderLevel = Convert.ToInt32(reorderLeveTextBox.Text);
                    int availableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                    if (availableQuantity <= 0)
                    {
                        MessageBox.Show("Insufficient Item!", "Insufficient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        stockOutQuantityTextBox.Focus();
                        return;
                    }
                    item.StockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
                    item.Id = Convert.ToInt32(itemsComboBox.SelectedValue);
                    item.CompanyName = companiesComboBox.Text;
                    item.ItemName = itemsComboBox.Text;
                    if (item.StockOutQuantity <= 0)
                    {
                        MessageBox.Show("Quantity ' 0 ' is not accept!", "NULL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        stockOutQuantityTextBox.Focus();
                        return;
                    }
                    if (item.StockOutQuantity > availableQuantity)
                    {
                        MessageBox.Show("Insufficient Item!", "Insufficient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        stockOutQuantityTextBox.Focus();
                        return;
                    }
                    if (item.StockOutQuantity >= (availableQuantity - reOrderLevel))
                    {
                        reorderLevelMessageLabel.Text = "Please Restock This Item!";
                    }
                    if (items.Count > 0)
                    {
                        int checkOutQuantity = 0;
                        var checkQuantityList = items.Where(c => c.Id == item.Id).Select(c => c.StockOutQuantity).ToList();
                        foreach (var data in checkQuantityList)
                        {
                            checkOutQuantity += data;
                        }
                        if ((item.StockOutQuantity + checkOutQuantity) > availableQuantity)
                        {
                            MessageBox.Show("Insufficient Item!", "Insufficient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            stockOutQuantityTextBox.Focus();
                            return;
                        }
                        if ((checkOutQuantity + item.StockOutQuantity) >= (availableQuantity - reOrderLevel))
                        {
                            reorderLevelMessageLabel.Text = "Please Restock This Item!";
                        }
                    }
                    items.Add(item);
                    BindItemsGridView(items);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindItemsGridView(List<Item> items)
        {
            try
            {
                int serial = 0;
                itemsListGirdView.Rows.Clear();
                foreach (var item in items)
                {
                    serial++;
                    itemsListGirdView.Rows.Add(serial, item.ItemName, item.CompanyName, item.StockOutQuantity);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsFormValid()
        {
            if (companiesComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select company name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companiesComboBox.Focus();
                return false;
            }
            if (categoriesComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select category name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                categoriesComboBox.Focus();
                return false;
            }
            if (itemsComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select item name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itemsComboBox.Focus();
                return false;
            }
            if (stockOutQuantityTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter stock out quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stockOutQuantityTextBox.Clear();
                stockOutQuantityTextBox.Focus();
                return false;
            }
            return true;
        }

        private void stockOutQuantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFormValid())
                {
                    bool isSave = false;
                    if (items.Count <= 0)
                    {
                        MessageBox.Show("Please add your items!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string outType = "Sell";
                    int userId = _userManager.GetUserId(LoginForm.UserName, LoginForm.Password);
                    DateTime date = DateTime.Now;
                    foreach (var data in items)
                    {
                        int row = _stockOutManager.SaveItemQuantityInStockOut(data.Id, outType, data.StockOutQuantity, userId, date);
                        if (row > 0)
                        {
                            isSave = true;
                        }
                    }
                    if (isSave)
                    {
                        MessageBox.Show("Stok Out Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Stock Out Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            itemsListGirdView.Rows.Clear();
            items.Clear();
            companiesComboBox.SelectedIndex = 0;
            stockOutQuantityTextBox.Clear();
        }

        private void LostButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFormValid())
                {
                    bool isSave = false;
                    if (items.Count <= 0)
                    {
                        MessageBox.Show("Please add your items!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string outType = "Lost";
                    int userId = _userManager.GetUserId(LoginForm.UserName, LoginForm.Password);
                    DateTime date = DateTime.Now;
                    foreach (var data in items)
                    {
                        int row = _stockOutManager.SaveItemQuantityInStockOut(data.Id, outType, data.StockOutQuantity, userId, date);
                        if (row > 0)
                        {
                            isSave = true;
                        }
                    }
                    if (isSave)
                    {
                        MessageBox.Show("Stok Out Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Stock Out Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DamageButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFormValid())
                {
                    bool isSave = false;
                    if (items.Count <= 0)
                    {
                        MessageBox.Show("Please add your items!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string outType = "Damage";
                    int userId = _userManager.GetUserId(LoginForm.UserName, LoginForm.Password);
                    DateTime date = DateTime.Now;
                    foreach (var data in items)
                    {
                        int row = _stockOutManager.SaveItemQuantityInStockOut(data.Id, outType, data.StockOutQuantity, userId, date);
                        if (row > 0)
                        {
                            isSave = true;
                        }
                    }
                    if (isSave)
                    {
                        MessageBox.Show("Stok Out Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Stock Out Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
