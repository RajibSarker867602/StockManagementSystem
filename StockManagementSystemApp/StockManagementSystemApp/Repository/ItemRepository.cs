using StockManagementSystem.Models;
using StockManagementSystemApp.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem.Repository
{
    public class ItemRepository
    {
        ConnectionClass connectionClass = new ConnectionClass();
        private string commandString;
        private SqlCommand sqlCommand;
        public DataTable GetCategoriesInCategoryCombobox()
        {
            DataTable dataTable = new DataTable();
            try
            {
                
                commandString = @"SELECT * FROM Categories";
                sqlCommand = new SqlCommand(commandString, connectionClass.GetConnection());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

                dataAdapter.Fill(dataTable);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connectionClass.GetClose();
            }
            return dataTable;
        }
        public DataTable GetCompanysInCompanyCombobox()
        {
            DataTable dataTable = new DataTable();
            try
            {
                commandString = @"SELECT * FROM Companys";
                sqlCommand = new SqlCommand(commandString, connectionClass.GetConnection());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connectionClass.GetClose();
            }
            return dataTable;
        }
        public int InsertItem(Item item)
        {
            int isExecuted = 0;
            try
            {
                commandString = @"INSERT INTO Items  VALUES('" + item.itemName + "','" + item.Reorderlevel + "'," + item.CategoryId + "," + item.CompanyId + " ,'" + item.UserId + "','" + item.CreatedDate + "')";
                sqlCommand = new SqlCommand(commandString, connectionClass.GetConnection());

                isExecuted = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connectionClass.GetClose();
            }
            return isExecuted;
        }
        public bool IsExistName(Item item)
        {
            bool isDuplicate=false ;
            try
            {
                ConnectionClass connectionClass = new ConnectionClass();
                commandString = "Select * From Items Where Name='" + item.itemName + "'";
                sqlCommand = new SqlCommand(commandString, connectionClass.GetConnection());
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
                connectionClass.GetClose();
            }
            return isDuplicate;
        }
        public DataTable ShowItemsInDatagridview()
        {
            DataTable dataTable = new DataTable();
            try
            {
                commandString = @"SELECT  i.Id as SL,i.Name,ReOrderLevel,c.Name as Category, a.Name as Company  From Items as i INNER JOIN Categories as c ON c.Id=i.CategoryId INNER JOIN Companys as a ON a.Id=i.CompanyId";
                sqlCommand = new SqlCommand(commandString, connectionClass.GetConnection());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connectionClass.GetClose();
            }
            return dataTable;
        }
        public int UpdateGridviewRow(Item item)
        {
            int isExecuted = 0;
            try
            {
                ConnectionClass connectionClass = new ConnectionClass();
                commandString = @"UPDATE Items SET Name =  '" +item.itemName + "' WHERE ID = " + item.Id+ "";
                sqlCommand = new SqlCommand(commandString, connectionClass.GetConnection());
                isExecuted = sqlCommand.ExecuteNonQuery();
                connectionClass.GetClose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return isExecuted;
        }
    }
}

