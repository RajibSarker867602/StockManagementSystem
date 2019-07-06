using StockManagementSystemApp.Manager;
using StockManagementSystemApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace StockManagementSystemApp.UI
{
    public partial class searchAndViewItemsSummaryForm : Form
    {
        public searchAndViewItemsSummaryForm()
        {
            InitializeComponent();
        }
        Item item = new Item();
        CompanyManager _companyManager = new CompanyManager();
        CategoryManager _categoryManager = new CategoryManager();
        StockInManager _stockInManager = new StockInManager();
        StockOutManager _stockOutManager = new StockOutManager();
        ItemManager _itemManager = new ItemManager();

        private void searchAndViewItemsSummaryForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCompaniesComboBox();
                LoadCategoryComboBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategoryComboBox()
        {
            try
            {
                List<Category> categories = _categoryManager.GetCategories();
                Category category = new Category();
                category.Id = 0;
                category.CategoryName = "--Select--";
                categories.Insert(0, category);
                categoriesComboBox.DataSource = null;
                categoriesComboBox.DataSource = categories;
                categoriesComboBox.DisplayMember = "CategoryName";
                categoriesComboBox.ValueMember = "Id";
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
            catch(Exception ex)
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
                    }
                    else
                    {
                        List<string> data = new List<string>();
                        data.Add("No Data Found!");
                        categoriesComboBox.DataSource = data;
                    }
                }
                else
                {
                    LoadCategoryComboBox();
                    itemsGridView.Rows.Clear();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(companiesComboBox.SelectedIndex<=0 && categoriesComboBox.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select your search criteria!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(companiesComboBox.SelectedIndex > 0 && categoriesComboBox.SelectedIndex > 0)
                {
                    List<Item> items = new List<Item>();
                    int companyId = Convert.ToInt32(companiesComboBox.SelectedValue);
                    int categoryId = Convert.ToInt32(categoriesComboBox.SelectedValue);
                    var itemList = _itemManager.GetItems().Where(c => c.CompanyId == companyId && c.CategoryId == categoryId).ToList();
                    foreach (var data in itemList)
                    {
                        Item item = new Item();
                        int stockInQuantity = 0;
                        int stockOutQuantity = 0;
                        stockInQuantity += _stockInManager.GetItemAvailableQuantity(data.Id);
                        stockOutQuantity += _stockOutManager.GetItemStockOutQuantity(data.Id);
                        item.Id = data.Id;
                        item.ItemName = data.ItemName;
                        item.CompanyName = data.CompanyName;
                        item.CategoryName = data.CategoryName;
                        item.ReorderLevel = data.ReorderLevel;
                        item.AvailableQuantity = stockInQuantity - stockOutQuantity;
                        items.Add(item);
                    }
                    BindItemsGridView(items);
                    return;
                }
                if (companiesComboBox.SelectedIndex > 0)
                {
                    int companyId = Convert.ToInt32(companiesComboBox.SelectedValue);
                    var itemList = _itemManager.GetItems().Where(c => c.CompanyId == companyId).ToList();
                    List<Item> items = new List<Item>();
                    foreach (var data in itemList)
                    {
                        Item item = new Item();
                        int stockInQuantity = 0;
                        int stockOutQuantity = 0;
                        stockInQuantity += _stockInManager.GetItemAvailableQuantity(data.Id);
                        stockOutQuantity += _stockOutManager.GetItemStockOutQuantity(data.Id);
                        item.Id = data.Id;
                        item.ItemName = data.ItemName;
                        item.CompanyName = data.CompanyName;
                        item.CategoryName = data.CategoryName;
                        item.ReorderLevel = data.ReorderLevel;
                        item.AvailableQuantity = stockInQuantity - stockOutQuantity;
                        items.Add(item);
                    }
                    BindItemsGridView(items);
                    return;
                }
                if (categoriesComboBox.SelectedIndex > 0)
                {
                    int categoryId = Convert.ToInt32(categoriesComboBox.SelectedValue);
                    var itemList = _itemManager.GetItems().Where(c => c.CategoryId == categoryId).ToList();
                    List<Item> items = new List<Item>();
                    foreach (var data in itemList)
                    {
                        Item item = new Item();
                        int stockInQuantity=0;
                        int stockOutQuantity = 0;
                        stockInQuantity += _stockInManager.GetItemAvailableQuantity(data.Id);
                        stockOutQuantity += _stockOutManager.GetItemStockOutQuantity(data.Id);
                        item.Id = data.Id;
                        item.ItemName = data.ItemName;
                        item.CompanyName = data.CompanyName;
                        item.CategoryName = data.CategoryName;
                        item.ReorderLevel = data.ReorderLevel;
                        item.AvailableQuantity = stockInQuantity - stockOutQuantity;
                        items.Add(item);
                    }
                    BindItemsGridView(items);
                    return;
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
                itemsGridView.Rows.Clear();
                int serial = 0;
                foreach (var item in items)
                {
                    serial++;
                    itemsGridView.Rows.Add(serial, item.ItemName, item.CompanyName, item.CategoryName, item.AvailableQuantity, item.ReorderLevel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (categoriesComboBox.SelectedIndex <= 0)
                {
                    itemsGridView.Rows.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PdfButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemsGridView.Rows.Count > 0)
                {
                    GeneratePdf(itemsGridView, "Report");
                }
                else
                {
                    MessageBox.Show("No items available!", "NULL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GeneratePdf(DataGridView itemsGridView, string fileName)
        {
            try
            {
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                PdfPTable pdfPTable = new PdfPTable(itemsGridView.Columns.Count);
                pdfPTable.DefaultCell.Padding = 3;
                pdfPTable.WidthPercentage = 100;
                pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPTable.DefaultCell.BorderWidth = 1;

                iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                //add title
                Paragraph p1 = new Paragraph();
                p1.Alignment = Element.ALIGN_CENTER;
                p1.Add(new Chunk("Stock Management System"));

                Paragraph pItems = new Paragraph();
                pItems.Alignment = Element.ALIGN_CENTER;
                pItems.Add(new Chunk("Item List"));

                Paragraph pDate = new Paragraph();
                pDate.Alignment = Element.ALIGN_LEFT;
                pDate.Add(new Chunk("Date : " + DateTime.Now.ToShortDateString()));
                //Add a line seperation
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                //add header
                foreach (DataGridViewColumn column in itemsGridView.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfPTable.AddCell(cell);
                }
                //add datarow
                foreach (DataGridViewRow row in itemsGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfPTable.AddCell(new Phrase(cell.Value.ToString(), text));
                    }
                }
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = fileName;
                saveFileDialog.DefaultExt = ".pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(document, fileStream);
                        document.Open();
                        document.Add(p1);
                        document.Add(pItems);
                        document.Add(pDate);
                        document.Add(p);
                        document.Add(new Paragraph("\n"));
                        document.Add(pdfPTable);
                        document.Close();
                        fileStream.Close();
                        MessageBox.Show("Report has been Saved...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
