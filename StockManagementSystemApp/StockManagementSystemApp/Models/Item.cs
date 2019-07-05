using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string itemName { get; set; }
        public int Reorderlevel { get; set; }
        public int CategoryId { set; get; }
        public int CompanyId { set; get; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}