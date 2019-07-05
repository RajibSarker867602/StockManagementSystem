using StockManagementSystem.Repository;
using StockManagementSystem.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Manager
{
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();
        public DataTable GetCategoriesInCategoryCombobox()
        {
            return _itemRepository.GetCategoriesInCategoryCombobox();
        }
        public DataTable GetCompanysInCompanyCombobox()
        {
            return _itemRepository.GetCompanysInCompanyCombobox();
        }
        public int InsertItem(Item item)
        {
            return _itemRepository.InsertItem(item);
        }
        public bool IsExistName(Item item)
        {
            return _itemRepository.IsExistName(item);
        }
        public DataTable ShowItemsInDatagridview()
        {
            return _itemRepository.ShowItemsInDatagridview();
        }
        public int UpdateGridviewRow(Item item)
        {
            return _itemRepository.UpdateGridviewRow(item);
        }

        //added by group manager

        public List<Item> GetItems()
        {
            return _itemRepository.GetItems();
        }
        public List<Item> GetItemsByCaGetItemsByCategoryAndCompanytegory(int categoryId, int companyId)
        {
            return _itemRepository.GetItemsByCategoryAndCompany(categoryId, companyId);
        }
        public int GetItemReorderLevel(Item item)
        {
            return _itemRepository.GetItemReorderLevel(item);
        }
    }
}
