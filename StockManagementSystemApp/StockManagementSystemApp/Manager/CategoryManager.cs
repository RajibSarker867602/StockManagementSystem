﻿using StockManagementSystemApp.Models;
using StockManagementSystemApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Manager
{
    class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        public string SaveCategory(Category category)
        {
            int row = _categoryRepository.SaveCategory(category);
            if (row > 0)
            {
                return "Category Saved Successful.";
            }
            return "Save Failed!";
        }
        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
        public string UpdateCategory(Category category)
        {
            int row = _categoryRepository.UpdateCategory(category);
            if (row > 0)
            {
                return "Category Update Successful.";
            }
            return "Update Failed!";
        }
        public bool IsExistCategory(Category category)
        {
            if (_categoryRepository.IsExistCategory(category))
            {
                return true;
            }
            return false;
        }
        public List<Category> GetCategoriesByCompany(Company company)
        {
            return _categoryRepository.GetCategoriesByCompany(company);
        }
    }
    
}
