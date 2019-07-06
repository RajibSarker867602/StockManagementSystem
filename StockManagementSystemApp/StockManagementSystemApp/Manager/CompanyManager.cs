using StockManagementSystemApp.Models;
using StockManagementSystemApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Manager
{
    class CompanyManager
    {
        CompanyRepository _companyRepository = new CompanyRepository();
        public string SaveCompany(Company company)
        {
            int row = _companyRepository.SaveCompany(company);
            if (row > 0)
            {
                return "Company Saved Successful.";
            }
            return "Save Failed!";
        }
        public List<Company> GetCompaies()
        {
            return _companyRepository.GetCompanies();
        }
        public string UpdateCompany(Company company)
        {
            int row = _companyRepository.UpdateCompany(company);
            if (row > 0)
            {
                return "Company Update Successful.";
            }
            return "Update Failed!";
        }
        public bool IsExistCompany(Company company)
        {
            if (_companyRepository.IsExistCompany(company))
            {
                return true;
            }
            return false;
        }
    }
}
