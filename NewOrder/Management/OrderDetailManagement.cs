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
    class OrderDetailManagement
    {
        string _connString;
        SqlDataAdapter adapter;
        DataTable orderDetailsTable;
        SqlCommandBuilder commandBuilder;
        OrderManagement orderManagement;
        public OrderDetailManagement()
        {
            orderManagement = new OrderManagement();
            _connString = ConfigurationManager.ConnectionStrings["_connectionString"].ToString();
            string query = "Select c.CustomerID,c.CompanyName,c.ContactTitle,o.OrderDate,p.ProductName,od.Quantity,(od.Quantity*od.UnitPrice*(1-od.Discount)) Price, o.OrderID from Customers c join Orders o on o.CustomerID=c.CustomerID join[Order Details] od on od.OrderID = o.OrderID join Products p on p.ProductID = od.ProductID where o.EmployeeID is NULL";
            adapter = new SqlDataAdapter(query, _connString);
            orderDetailsTable = new DataTable();
            adapter.Fill(orderDetailsTable);
            commandBuilder = new SqlCommandBuilder(adapter);
        }

        public List<OrderDetail> GetUnsignedOrders()
        {
            List<OrderDetail> unsignedOrders = new List<OrderDetail>();

            orderDetailsTable.Clear();
            adapter.Fill(orderDetailsTable);

            foreach (DataRow item in orderDetailsTable.Rows)
            {
                unsignedOrders.Add(new OrderDetail()
                {
                    CustomerID = item[0].ToString(),
                    CustomerCompanyName = item[1].ToString(),
                    ContactTitle = item[2].ToString(),
                    OrderDate = Convert.ToDateTime(item[3]),
                    ProductName = item[4].ToString(),
                    Quantity = Convert.ToInt32(item[5]),
                    TotalPrice = Convert.ToDecimal(item[6]),
                    OrderID = Convert.ToInt32(item[7])
                });
            }

            return unsignedOrders;
        }

        public OrderDetail GetOrderDetailByOrderID(int orderID)
        {
            OrderManagement orderManagement = new OrderManagement();
            foreach (OrderDetail item in GetUnsignedOrders())
            {
                if (item.OrderID == orderID)
                {
                    return item;
                }
            }
            return null;
        }

        public void InsertIntoOrderDetails(Order order, Product product)
        {
            string query = "Select * From [Order Details]";
            SqlDataAdapter adapter2 = new SqlDataAdapter(query, _connString);
            DataTable orderDetailsTable = new DataTable();
            adapter2.Fill(orderDetailsTable);

            commandBuilder = new SqlCommandBuilder(adapter2);
            adapter2.UpdateCommand = commandBuilder.GetUpdateCommand();

            DataRow dataRow = orderDetailsTable.NewRow();
            dataRow[0] = orderManagement.GetOrderID();
            dataRow[1] = product.ProductID;
            dataRow[2] = product.UnitPrice;
            dataRow[3] = order.Quantity;

            orderDetailsTable.Rows.Add(dataRow);
            adapter2.Update(orderDetailsTable);
        }
    }
}
