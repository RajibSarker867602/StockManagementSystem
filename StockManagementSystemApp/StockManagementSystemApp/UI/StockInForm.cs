using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystemApp.Models;
using StockManagementSystemApp.Manager;

namespace StockManagementSystemApp
{
    public partial class StockInForm : Form
    {
        StockInManager _stockInManagers = new StockInManager();
        StockOutManager _stockOutManager = new StockOutManager();
        private StockInModel stockinModel;
        public StockInForm()
        {
            InitializeComponent();
            stockinModel = new StockInModel();
        }

        private void StockInSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFormValid())
                {
                    DateTime dateTime = DateTime.UtcNow.Date;
                    stockinModel.StockInQty = Convert.ToInt32(stockInqtyTextBox.Text);
                    stockinModel.CreatedDate = dateTime.ToString("dd/MM/yyyy");
                    int isExecuted;
                    isExecuted = _stockInManagers.InsertStock(stockinModel);
                    if (isExecuted > 0)
                    {
                        MessageBox.Show("Successfully Data Saved.");
                        stockInDataGridView.DataSource = _stockInManagers.ShowStockIn();
                        stockInqtyTextBox.Clear();
                        reorderLavelTextBox.Clear();
                        availableQtyTextBox.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Not Saved");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsFormValid()
        {
            if (comNameComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select company name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comNameComboBox.Focus();
                return false;
            }
            if (catNameComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select category name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                catNameComboBox.Focus();
                return false;
            }
            if (itemNameComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select item name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itemNameComboBox.Focus();
                return false;
            }
            if (stockInqtyTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter stock in quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stockInqtyTextBox.Clear();
                stockInqtyTextBox.Focus();
                return false;
            }
            return true;
        }

        private void StockIn_Load(object sender, EventArgs e)
        {
            try
            {
                comNameComboBox.DataSource = _stockInManagers.LoadCompanys();
                comNameComboBox.DisplayMember = "Name";
                comNameComboBox.ValueMember = "Id";

                stockInDataGridView.DataSource = _stockInManagers.ShowStockIn();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                int selectedValue = (int)cmb.SelectedValue;
                string itemId = String.Format("{0}", selectedValue);
                stockinModel.ItemId = Convert.ToInt32(itemId);
                int itemID = Convert.ToInt32(itemNameComboBox.SelectedValue);
                int reOrderLavel = _stockInManagers.ReOrderLavel(stockinModel);
                reorderLavelTextBox.Text = reOrderLavel.ToString();
                int avaiLavelQty = _stockInManagers.GetItemAvailableQuantity(itemID) - _stockOutManager.GetItemStockOutQuantity(itemID);
                availableQtyTextBox.Text = avaiLavelQty.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                int selectedValue = (int)cmb.SelectedValue;
                string comId = String.Format("{0}", selectedValue);
                stockinModel.ComId = Convert.ToInt32(comId);
                _stockInManagers.CatWiseItems(stockinModel);
                catNameComboBox.DataSource = _stockInManagers.ComWiseCat(stockinModel);
                catNameComboBox.DisplayMember = "Name";
                catNameComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void catNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                int selectedValue = (int)cmb.SelectedValue;
                string catId = String.Format("{0}", selectedValue);
                stockinModel.CatId = Convert.ToInt32(catId);
                stockinModel.ComId = Convert.ToInt32(comNameComboBox.SelectedValue);
                _stockInManagers.CatWiseItems(stockinModel);
                itemNameComboBox.DataSource = _stockInManagers.CatWiseItems(stockinModel);
                itemNameComboBox.DisplayMember = "Name";
                itemNameComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
