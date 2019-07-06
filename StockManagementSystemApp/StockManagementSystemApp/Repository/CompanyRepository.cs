using StockManagementSystemApp.Models;
using StockManagementSystemApp.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystemApp.Repository
{
    class CompanyRepository
    {
        ConnectionClass connection;
        SqlCommand cmd;
        SqlDataReader reader;
        public int SaveCompany(Company company)
        {
            int row = 0;
            connection = new ConnectionClass();
            string query = "Insert Into Companys(Name,UserId,CreatedDate) Values(@name,@userId,@date)";
            try
            {
                cmd = new SqlCommand(query, connection.GetConnection());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", company.CompanyName);
                cmd.Parameters.AddWithValue("@userId", company.UserId);
                cmd.Parameters.AddWithValue("@date", company.CreatedDate);
                row = cmd.ExecuteNonQuery();

                if (row > 0)
                    return row;
            }
            catch (Exception exception)
            {
                row = 0;
            }
            finally
            {
                connection.GetClose();
            }
            return row;
        }
        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            connection = new ConnectionClass();
            string query = "Select * From Companys";
            try
            {
                cmd = new SqlCommand(query, connection.GetConnection());
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company company = new Company();
                    company.Id = (int)(reader["Id"]);
                    company.CompanyName = reader["Name"].ToString();
                    company.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);

                    companies.Add(company);
                }
            }
            catch (Exception exception)
            {
                companies = null;
            }
            finally
            {
                connection.GetClose();
            }
            return companies;
        }
        public int UpdateCompany(Company company)
        {
            int row = 0;
            connection = new ConnectionClass();
            string query = "Update Companys SET Name=@name,UserId=@userId,CreatedDate=@date Where Id=@id";
            try
            {
                cmd = new SqlCommand(query, connection.GetConnection());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", company.Id);
                cmd.Parameters.AddWithValue("@name", company.CompanyName);
                cmd.Parameters.AddWithValue("@userId", company.UserId);
                cmd.Parameters.AddWithValue("@date", company.CreatedDate);
                row = cmd.ExecuteNonQuery();

                if (row > 0)
                    return row;
            }
            catch (Exception exception)
            {
                row = 0;
            }
            finally
            {
                connection.GetClose();
            }
            return row;
        }
        public bool IsExistCompany(Company company)
        {
            connection = new ConnectionClass();
            string query = "Select * From Companys Where Name=@name";
            try
            {
                cmd = new SqlCommand(query, connection.GetConnection());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", company.CompanyName);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return true;
                }
            }
            catch (Exception exception)
            {
                return false;
            }
            finally
            {
                connection.GetClose();
            }
            return false;
        }
    }
}
