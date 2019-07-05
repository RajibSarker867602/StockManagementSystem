using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Models
{
    class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
