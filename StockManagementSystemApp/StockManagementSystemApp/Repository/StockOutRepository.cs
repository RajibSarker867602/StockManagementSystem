using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApp.Models;
using StockManagementSystemApp.Repository;

namespace StockManagementSystemApp.Repository
{
    class StockOutRepository
    {
        ConnectionClass connection;
        SqlCommand cmd;
        SqlDataReader reader;
        public int SaveItemQuantityInStockOut(int itemId,string outType,int quantity,int userId,DateTime date)
        {
            int row = 0;
            connection = new ConnectionClass();
            string query = "Insert Into StockOut(ItemId,OutType,Quantity,UserId,CreatedDate) Values(@id,@outType,@quantity,@userId,@date)";
            try
            {
                cmd = new SqlCommand(query, connection.GetConnection());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", itemId);
                cmd.Parameters.AddWithValue("@outType", outType);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@date", date);
                row = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                row = 0;
            }
            finally
            {
                connection.GetClose();
            }
            return row;
        }
        public int GetItemStockOutQuantity(int id)
        {
            int quantity = 0;
            connection = new ConnectionClass();
            string query = "Select Quantity From StockOut Where ItemId=@id";
            try
            {
                cmd = new SqlCommand(query, connection.GetConnection());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    quantity += Convert.ToInt32(reader["Quantity"]);
                }
            }
            catch (Exception ex)
            {
                quantity = 0;
            }
            finally
            {
                connection.GetClose();
            }
            return quantity;
        }
        public List<Item> GetItemsByDateAndOutTpe(Item itm)
        {
            List<Item> items = new List<Item>();
            connection = new ConnectionClass();
            string query = "Select i.Name as ItemName,c.Name as CompanyName,sum(s.Quantity) as Quantity From StockOut as s inner join Items as i on s.ItemId=i.Id Inner join Companys as c on i.CompanyId=c.Id where s.CreatedDate Between @fromDate and @toDate and s.OutType=@outType group by i.Name,c.Name";
            try
            {
                cmd = new SqlCommand(query, connection.GetConnection());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fromDate", itm.FromDate);
                cmd.Parameters.AddWithValue("@toDate", itm.ToDate);
                cmd.Parameters.AddWithValue("@outType", itm.StockOutType);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.ItemName = reader["ItemName"].ToString();
                    item.CompanyName = reader["CompanyName"].ToString();
                    item.StockOutQuantity = Convert.ToInt32(reader["Quantity"]);
                    items.Add(item);
                }
            }
            catch(Exception ex)
            {
                items = null;
            }
            finally
            {
                connection.GetClose();
            }
            return items;
        }
    }
}
