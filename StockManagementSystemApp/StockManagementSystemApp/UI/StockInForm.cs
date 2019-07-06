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
      
        StockInManagers _stockInManagers = new StockInManagers();
        private StockInModel stockinModel;
        public StockInForm()
        {
            InitializeComponent();
            stockinModel = new StockInModel();
        }

        private void StockInSaveButton_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            stockinModel.StockInQty = Convert.ToInt32(stockInqtyTextBox.Text);
            stockinModel.CreatedDate = dateTime.ToString("dd/MM/yyyy");

            int isExecuted;
            isExecuted = _stockInManagers.InsertStock(stockinModel);

            if (isExecuted > 0)
            {
                MessageBox.Show("Successfully Data Saved.");
                stockInqtyTextBox.Text = "";
                reorderLavelTextBox.Text = "";
                availableQtyTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            stockInDataGridView.DataSource = _stockInManagers.ShowStockIn();

        }

        private void StockIn_Load(object sender, EventArgs e)
        {
            comNameComboBox.DataSource = _stockInManagers.LoadCompanys();
            comNameComboBox.DisplayMember = "Name";
            comNameComboBox.ValueMember = "Id";
            
            stockInDataGridView.DataSource = _stockInManagers.ShowStockIn();
        }

        private void itemNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int itemId = Convert.ToInt32(itemNameComboBox.Text);
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int selectedValue = (int)cmb.SelectedValue;
            string itemId = String.Format("{0}", selectedValue);
            stockinModel.ItemId =Convert.ToInt32(itemId);

           int reOrderLavel;
            reOrderLavel = _stockInManagers.ReOrderLavel(stockinModel);
                  
            reorderLavelTextBox.Text = reOrderLavel.ToString();

            int avaiLavelQty;
            avaiLavelQty = _stockInManagers.AvaiLavelQty(stockinModel);

            availableQtyTextBox.Text = avaiLavelQty.ToString();

        }

        private void comNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void stockInDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           stockinModel.Id = stockInDataGridView.CurrentRow.Cells["idDataGridViewTextBoxColumn"].FormattedValue.ToString();
           
           stockInIdTextBox.Text = stockinModel.Id.ToString();
           StockInSaveButton.Text = "Update";

        }

        private void catNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int selectedValue = (int)cmb.SelectedValue;
            string catId = String.Format("{0}", selectedValue);
            //MessageBox.Show(catId);
            stockinModel.CatId = Convert.ToInt32(catId);
            _stockInManagers.CatWiseItems(stockinModel);
            itemNameComboBox.DataSource = _stockInManagers.CatWiseItems(stockinModel);
            itemNameComboBox.DisplayMember = "Name";
            itemNameComboBox.ValueMember = "Id";
        }

        private void stockInDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            stockinModel.Id = null;
            stockInIdTextBox.Text = null;
            StockInSaveButton.Text = "Save";

        }
    }
}
