using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApp.Models;
using StockManagementSystemApp.Repository;

namespace StockManagementSystemApp.Manager
{
    public class StockInManager
    {
       StockInRepository _stockInRepository = new StockInRepository();
        public DataTable LoadCompanys()
        {
            return _stockInRepository.LoadCompanys();
        }
        public DataTable LoadCategorys()
        {
            return _stockInRepository.LoadCategorys();
        }
        public DataTable CatWiseItems(StockInModel stockInModel)
        {
            return _stockInRepository.CatWiseItems(stockInModel);
        }

        public DataTable ComWiseCat(StockInModel stockInModel)
        {
            return _stockInRepository.ComWiseCat(stockInModel);
        }

        public DataTable LoadItems()
        {
            return _stockInRepository.LoadItems();
        }

        public int InsertStock(StockInModel stockinModel)
        {
            return _stockInRepository.InsertStock(stockinModel);
        }
        public DataTable ShowStockIn()
        {
            return _stockInRepository.ShowStockIn();
        }

        public int ReOrderLavel(StockInModel stockinModel)
        {
            return _stockInRepository.ReOrderLavel(stockinModel);
        }

        public int AvaiLavelQty(StockInModel stockinModel)
        {
            return _stockInRepository.AvaiLavelQty(stockinModel);
        }
        public int GetItemAvailableQuantity(int id)
        {
            return _stockInRepository.GetItemAvailableQuantity(id);
        }
    }
}
