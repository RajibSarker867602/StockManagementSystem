using StockManagementSystemApp.Models;
using StockManagementSystemApp.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Repository
{
    public class UserRepository
    {
        ConnectionClass connection;
        SqlCommand cmd;
        SqlDataReader reader;
        public int IsExistUser(User user)
        {
            int count = 0;
            connection = new ConnectionClass();
            string query = "Select Count(*)cnt From [User] Where UserName=@userName AND Password=@password";
            try
            {
                cmd = new SqlCommand(query, connection.GetConnection());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@userName", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);
                count = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                count = 0;
            }
            finally
            {
                connection.GetClose();
            }
            return count;
        }
        public int GetUserId(string userName,string password)
        {
            int userId = 0;
            connection = new ConnectionClass();
            string query = "Select Id From [User] Where UserName='" + userName + "' AND Password='" + password + "'";
            try
            {
                cmd = new SqlCommand(query,connection.GetConnection());
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userId = Convert.ToInt32(reader["Id"]);
                }
            }
            catch(Exception ex)
            {
                userId = 0;
            }
            finally
            {
                connection.GetClose();
            }
            return userId;
        }
    }
}
