using NewOrder.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOrder.Management
{
    class OrderManagement
    {
        string _connString;
        SqlDataAdapter adapter;
        DataTable orderTable;
        SqlCommandBuilder commandBuilder;
        string query;

        public OrderManagement()
        {
            _connString = ConfigurationManager.ConnectionStrings["_connectionString"].ToString();
            query = "Select * From Orders";
            adapter = new SqlDataAdapter(query, _connString);
            orderTable = new DataTable();
            adapter.Fill(orderTable);
            commandBuilder = new SqlCommandBuilder(adapter);
        }

        public void InsertIntoOrders(Order order)
        {
            DataRow dataRow = orderTable.NewRow();
            dataRow[1] = order.CustomerID;
            dataRow[3] = order.OrderDate;

            orderTable.Rows.Add(dataRow);
            adapter.Update(orderTable);
        }

        public int GetOrderID()
        {
            string query = "Select MAX(OrderID) From Orders";
            int orderID = 0;

            adapter = new SqlDataAdapter(query, _connString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                orderID = Convert.ToInt32(item[0]);
            }

            return orderID;
        }       

        public void UpdateOrders(OrderDetail od, int employeeID, DateTime requiredDate)
        {
            adapter = new SqlDataAdapter(query, _connString);
            DataTable unsignedOrdersTable = new DataTable();
            adapter.Fill(unsignedOrdersTable);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataRow dataRow = null;
            DataRow[] rows = unsignedOrdersTable.Select("EmployeeID is Null");
            foreach (DataRow item in rows)
            {
                if (od.OrderID == Convert.ToInt32(item[0]))
                {
                    dataRow = item;
                    break;
                }
            }

            dataRow[2] = employeeID;
            dataRow[4] = requiredDate;
            adapter.Update(unsignedOrdersTable);
        }

    }
}

