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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace StockManagementSystemApp.UI
{
    public partial class viewBetweenTwoDatesReportForm : Form
    {
        public viewBetweenTwoDatesReportForm()
        {
            InitializeComponent();
        }
        Item item = new Item();
        StockOutManager _stockOutManager = new StockOutManager();

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                item.FromDate = Convert.ToDateTime(fromDate.Text);
                item.ToDate = Convert.ToDateTime(toDate.Text);
                if (item.FromDate > item.ToDate)
                {
                    MessageBox.Show("From date must be less then or equal to todate!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fromDate.Focus();
                    return;
                }
                if (soldRadioButton.Checked)
                {
                    item.StockOutType = "Sell";
                }
                if (damageRadioButton.Checked)
                {
                    item.StockOutType = "Damage";
                }
                if (lostRadioButton.Checked)
                {
                    item.StockOutType = "Lost";
                }
                var items = _stockOutManager.GetItemsByDateAndOutTpe(item);
                if (items.Count <= 0)
                {
                    MessageBox.Show("No data found!", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                BindItemsGridView(items);
            }
            catch(Exception ex)
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
                    itemsGridView.Rows.Add(serial, item.ItemName, item.CompanyName, item.StockOutQuantity);
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
