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
    class CustomerManagement
    {
        string _connString;
        SqlDataAdapter adapter;
        DataTable customerTable;
        SqlCommandBuilder commandBuilder;

        public CustomerManagement()
        {
            _connString = ConfigurationManager.ConnectionStrings["_connectionString"].ToString();
            string query = "select CustomerID, CONCAT(City,'/',Country) [Password], CompanyName, ContactTitle, ContactName from Customers";
            adapter = new SqlDataAdapter(query, _connString);
            customerTable = new DataTable();
            adapter.Fill(customerTable);
            commandBuilder = new SqlCommandBuilder(adapter);
        }

        public List<Customer> GetCustomers()
        {
            customerTable.Clear();
            adapter.Fill(customerTable);
            List<Customer> customers = new List<Customer>();
            foreach (DataRow item in customerTable.Rows)
            {
                customers.Add(new Customer()
                {
                    CustomerID = item[0].ToString(),
                    Password = item[1].ToString(),
                    CompanyName = item[2].ToString(),
                    ContactTitle = item[3].ToString(),
                    ContactName = item[4].ToString()
                });
            }
            return customers;
        }

        public Customer GetCustomerLoginInfo(string username, string password)
        {
            Customer customer = null;
            customerTable.Clear();
            adapter.Fill(customerTable);

            DataRow[] rows = customerTable.Select($"CustomerID = '{username}' AND Password = '{password}'");
            if (rows.Length > 0)
            {
                foreach (DataRow item in rows)
                {
                    customer = new Customer()
                    {
                        CustomerID = item[0].ToString(),
                        Password = item[1].ToString()
                    };
                }
                return customer;
            }
            else
                throw new Exception("Girdiğiniz bilgileri kontrol edin.");
        }
    }
}
