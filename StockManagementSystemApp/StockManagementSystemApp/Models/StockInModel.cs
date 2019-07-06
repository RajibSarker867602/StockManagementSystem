using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Models
{
   public class StockInModel
    {
        public string Id { get; set; }
        public int ComId { get; set; }
        public int CatId { get; set; }
        public int ItemId { get; set; }
        public int ReorderLavel { get; set; }
        public int AvailableQty { get; set; }
        public int StockInQty { get; set; }
        public string CreatedDate { get; set; }
        public string Name { get; set; }
    }
}
