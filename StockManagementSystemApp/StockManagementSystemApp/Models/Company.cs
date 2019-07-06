﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Models
{
    class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
