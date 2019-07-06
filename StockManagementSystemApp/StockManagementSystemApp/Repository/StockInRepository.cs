using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApp.Models;


namespace StockManagementSystemApp.Repository
{
    public class StockInRepository
    {
        ConnectionClass connection;
        SqlCommand cmd;
        public DataTable LoadCompanys()
        {

            connection = new ConnectionClass();
            string query = @"SELECT * FROM Companys";
            cmd = new SqlCommand(query, connection.GetConnection());

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            DataRow row = dataTable.NewRow();

            row[0] = 0;
            row[1] = "Please Select Company";
            dataTable.Rows.InsertAt(row, 0);

            connection.GetClose();

            return dataTable;
        }
        
        public DataTable LoadCategorys()
        {

            connection = new ConnectionClass();
            string query  = @"SELECT * FROM Categories";
            cmd = new SqlCommand(query, connection.GetConnection());

       
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            connection.GetClose();

            return dataTable;
        }

        public DataTable CatWiseItems(StockInModel stockInModel)
        {

            connection = new ConnectionClass();
            string query = @"SELECT * FROM Items where CategoryId = '" + stockInModel.CatId+ "'";
            cmd = new SqlCommand(query, connection.GetConnection());

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.NewRow();
                row["Id"] = 0;
                row["Name"] = "Please Select Item";
                dataTable.Rows.InsertAt(row, 0);
            }
            connection.GetClose();

            return dataTable;
        }

        public DataTable ComWiseCat(StockInModel stockInModel)
        {
           
            connection = new ConnectionClass();
            string query = @"select c.Id, c.Name from Items as i left join Categories as c on c.Id = i.CategoryId  where i.CompanyId = '"+stockInModel.ComId+"'  group by c.Id, c.Name";
            cmd = new SqlCommand(query, connection.GetConnection());
      
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.NewRow();
                row["Id"] = 0;
                row["Name"] = "Please Select Cartegory";
                dataTable.Rows.InsertAt(row, 0);
            }

            connection.GetClose();

            return dataTable;
          
        }

        public DataTable LoadItems()
        {

            connection = new ConnectionClass();
            string query = @"SELECT * FROM Items";
            cmd = new SqlCommand(query, connection.GetConnection());

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            DataRow row = dataTable.NewRow();

            row[0] = 0;
            row[1] = "Please Select Item";
            dataTable.Rows.InsertAt(row, 0);

            //if (dataTable.Rows.Count > 0)
            //    districtComboBox.DataSource = dataTable;

            connection.GetClose();

            return dataTable;
        }
        public int InsertStock(StockInModel stockinModel)
        {

            connection = new ConnectionClass();
            if (!string.IsNullOrEmpty(stockinModel.Id))
            {
              string  query = @"Update StockIn set ItemId =  '" + stockinModel.ItemId + "', Quantity = '" + stockinModel.StockInQty + "' WHERE Id='" + stockinModel.Id + "'";
              cmd = new SqlCommand(query, connection.GetConnection());
            }
            else
            {
               string query = @"INSERT INTO StockIn (ItemId, Quantity, CreatedDate) VALUES ( " + stockinModel.ItemId + ", '" + stockinModel.StockInQty + "', '" + stockinModel.CreatedDate + "')";
               cmd = new SqlCommand(query, connection.GetConnection());
            }
            int isExecuted;
            isExecuted = cmd.ExecuteNonQuery();
    
            connection.GetClose();

            return isExecuted;
        }

        public DataTable ShowStockIn()
        {
            //commandString = @"select StockIn.ItemId, StockIn.CreatedDate,sum(StockInQty) as StockInQty, Items.Name from StockIn LEFT JOIN Items on StockIn.ItemId=Items.Id group by StockIn.ItemId,Items.Name,StockIn.CreatedDate";
            string query = @"select StockIn.id, Items.Name, StockIn.CreatedDate,StockIn.Quantity from StockIn LEFT JOIN Items on StockIn.ItemId=Items.Id";
            cmd = new SqlCommand(query, connection.GetConnection());


            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataTable.Columns.Add("SL", typeof(System.Int32));
            dataTable.Columns.Add("Action", typeof(System.String));
            int x = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                x = x + 1;
                row["SL"] = x;
                row["Action"] = "Edit";
            }

            //if (dataTable.Rows.Count > 0)
            //    displayDataGridView.DataSource = dataTable;


            connection.GetClose();
            return dataTable;
        }

        public int ReOrderLavel(StockInModel stockinModel)
        {

            connection = new ConnectionClass();
            string query = @"SELECT * FROM Items where Id='" + stockinModel.ItemId + "'";
            cmd = new SqlCommand(query, connection.GetConnection());


            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            int reQty = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                 reQty = Convert.ToInt32(row["ReOrderLevel"]);
            }
            int reOrderLavel;

            if (dataTable.Rows.Count > 0)
            {
                reOrderLavel = reQty;
            }
            else
            {
                reOrderLavel = 0;
            }

            connection.GetClose();
            return reOrderLavel;

        }

        public int AvaiLavelQty(StockInModel stockinModel)
        {

            connection = new ConnectionClass();
            string query = @"SELECT sum(StockIn.Quantity) AS totalStockInQty, sum(StockOut.Quantity) AS totalStockOutQty FROM StockIn 
LEFT OUTER JOIN StockOut ON StockIn.ItemId = StockOut.ItemId WHERE StockIn.ItemId = '" + stockinModel.ItemId +"'  GROUP BY StockIn.ItemId";
            cmd = new SqlCommand(query, connection.GetConnection());

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            //int avaiLavelQty = 0;
            int totalInStock = 0;
            int totalOutStock = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                if (!row.IsNull("totalStockInQty"))
                    totalInStock = Convert.ToInt32(row["totalStockInQty"]);
                if (!row.IsNull("totalStockOutQty"))
                    totalOutStock = Convert.ToInt32(row["totalStockOutQty"]);
            }
            int avilavelStock;

            if (dataTable.Rows.Count > 0)
            {
                avilavelStock = totalInStock - totalOutStock;
            }
            else
            {
                avilavelStock = 0;
            }

            connection.GetClose();
            return avilavelStock;

        }

        //public DataTable ReOrderLavel(StockInModel stockinModel)
        //{

        //    sqlConnection = new SqlConnection(connectionString);
        //    commandString = @"SELECT * FROM Items where Id='"+ stockinModel.ItemId + "'";
        //    sqlCommand = new SqlCommand(commandString, sqlConnection);

        //    sqlConnection.Open();

        //    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
        //    DataTable dataTable = new DataTable();
        //    dataAdapter.Fill(dataTable);

        //    DataRow row = dataTable.NewRow();

        //    row[0] = 0;
        //    row[1] = "Please Select Item";
        //    dataTable.Rows.InsertAt(row, 0);

        //    //if (dataTable.Rows.Count > 0)
        //    //    districtComboBox.DataSource = dataTable;

        //    sqlConnection.Close();

        //    return dataTable;
        //}
    }
}
