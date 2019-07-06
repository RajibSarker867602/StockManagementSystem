using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public int CategoryId { set; get; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public int StockInQuantity { get; set; }
        public int StockOutQuantity { get; set; }
        public string StockOutType { get; set; }
        public int AvailableQuantity { get; set; }
        public string Date { get; set; }
        public int StockInId { get; set; }
        public int CompanyId { set; get; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}