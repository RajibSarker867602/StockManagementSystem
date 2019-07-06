using StockManagementSystemApp.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystemApp.Models;

namespace StockManagementSystemApp.Repository
{
    public class ItemRepository
    {
        ConnectionClass connection;
        SqlDataReader reader;
        private string commandString;
        private SqlCommand sqlCommand;
        public DataTable GetCategoriesInCategoryCombobox()
        {
            DataTable dataTable = new DataTable();
            try
            {
                connection = new ConnectionClass();
                commandString = @"SELECT * FROM Categories";
                sqlCommand = new SqlCommand(commandString, connection.GetConnection());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

                dataAdapter.Fill(dataTable);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.GetClose();
            }
            return dataTable;
        }
        public DataTable GetCompanysInCompanyCombobox()
        {
            DataTable dataTable = new DataTable();
            try
            {
                connection = new ConnectionClass();
                commandString = @"SELECT * FROM Companys";
                sqlCommand = new SqlCommand(commandString, connection.GetConnection());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.GetClose();
            }
            return dataTable;
        }
        public int InsertItem(Item item)
        {
            connection = new ConnectionClass();
            int isExecuted = 0;
            try
            {
                commandString = @"INSERT INTO Items  VALUES('" + item.ItemName + "','" + item.ReorderLevel+ "'," + item.CategoryId + "," + item.CompanyId + " ,'" + item.UserId + "','" + item.CreatedDate + "')";
                sqlCommand = new SqlCommand(commandString, connection.GetConnection());

                isExecuted = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.GetClose();
            }
            return isExecuted;
        }
        public bool IsExistName(Item item)
        {
            connection = new ConnectionClass();
            bool isDuplicate=false ;
            try
            {
                
                commandString = "Select * From Items Where Name='" + item.ItemName + "'";
                sqlCommand = new SqlCommand(commandString, connection.GetConnection());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    isDuplicate = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.GetClose();
            }
            return isDuplicate;
        }
        public DataTable ShowItemsInDatagridview()
        {
            connection = new ConnectionClass();
            DataTable dataTable = new DataTable();
            try
            {
                commandString = @"SELECT  i.Id as SL,i.Name,ReOrderLevel,c.Name as Category, a.Name as Company  From Items as i INNER JOIN Categories as c ON c.Id=i.CategoryId INNER JOIN Companys as a ON a.Id=i.CompanyId";
                sqlCommand = new SqlCommand(commandString, connection.GetConnection());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.GetClose();
            }
            return dataTable;
        }
        public int UpdateGridviewRow(Item item)
        {
            connection = new ConnectionClass();
            int isExecuted = 0;
            try
            {
                commandString = @"UPDATE Items SET Name =  '" +item.ItemName + "' WHERE ID = " + item.Id+ "";
                sqlCommand = new SqlCommand(commandString, connection.GetConnection());
                isExecuted = sqlCommand.ExecuteNonQuery();
                connection.GetClose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return isExecuted;
        }
        //Extra method added by group manager in below
        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            connection = new ConnectionClass();
            string query = "Select i.Id AS ItemId,i.Name AS ItemName,i.ReOrderLevel,i.CreatedDate,i.UserId,co.Id as CompanyId,co.Name as CompanyName,ca.Id as CategoryId,ca.Name as CategoryName From Items AS i INNER JOIN Companys as co ON i.CompanyId=co.Id INNER JOIN Categories as ca ON i.CategoryId=ca.Id";
            try
            {
                sqlCommand = new SqlCommand(query, connection.GetConnection());
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.Id = (int)(reader["ItemId"]);
                    item.ItemName = reader["ItemName"].ToString();
                    item.ReorderLevel = Convert.ToInt32(reader["ReOrderLevel"]);
                    item.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                    item.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    item.CategoryName = reader["CategoryName"].ToString();
                    item.CompanyName = reader["CompanyName"].ToString();
                    item.UserId = Convert.ToInt32(reader["UserId"]);
                    items.Add(item);
                }
            }
            catch (Exception exception)
            {
                items = null;
            }
            finally
            {
                connection.GetClose();
            }
            return items;
        }
        public List<Item> GetItemsByCategoryAndCompany(int categoryId, int companyId)
        {
            List<Item> items = new List<Item>();
            connection = new ConnectionClass();
            string query = "Select * From Items Where CategoryId=@category AND CompanyId=@company";
            try
            {
                sqlCommand = new SqlCommand(query, connection.GetConnection());
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@category", categoryId);
                sqlCommand.Parameters.AddWithValue("@company", companyId);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.Id = Convert.ToInt32(reader["Id"]);
                    item.ItemName = reader["Name"].ToString();
                    items.Add(item);
                }
            }
            catch (Exception ex)
            {
                items = null;
            }
            finally
            {
                connection.GetClose();
            }
            return items;
        }
        public int GetItemReorderLevel(Item item)
        {
            Item particularItem = new Item();
            connection = new ConnectionClass();
            string query = "Select * From Items Where Id=@id";
            try
            {
                sqlCommand = new SqlCommand(query, connection.GetConnection());
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@id", item.Id);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    particularItem.ReorderLevel = Convert.ToInt32(reader["ReOrderLevel"]);
                }
            }
            catch (Exception exception)
            {
                particularItem.ReorderLevel = 0;
            }
            finally
            {
                connection.GetClose();
            }
            return particularItem.ReorderLevel;
        }
    }
}

