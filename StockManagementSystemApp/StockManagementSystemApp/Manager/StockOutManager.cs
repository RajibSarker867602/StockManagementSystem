using StockManagementSystemApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApp.Models;

namespace StockManagementSystemApp.Manager
{
    class StockOutManager
    {
        StockOutRepository _stockOutRepository = new StockOutRepository();
        public int SaveItemQuantityInStockOut(int itemId, string outType, int quantity, int userId, DateTime date)
        {
            return _stockOutRepository.SaveItemQuantityInStockOut(itemId,outType,quantity,userId,date);
        }
        public int GetItemStockOutQuantity(int id)
        {
            return _stockOutRepository.GetItemStockOutQuantity(id);
        }
        public List<Item> GetItemsByDateAndOutTpe(Item item)
        {
            return _stockOutRepository.GetItemsByDateAndOutTpe(item);
        }
    }
}
