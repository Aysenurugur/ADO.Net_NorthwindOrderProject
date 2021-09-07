using NewOrder.Entities;
using NewOrder.Enums;
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
    class ProductManagement
    {
        string _connString;
        SqlDataAdapter adapter;
        DataTable productTable;
        SqlCommandBuilder commandBuilder;

        public ProductManagement()
        {
            _connString = ConfigurationManager.ConnectionStrings["_connectionString"].ToString();
            string query = "select ProductID, ProductName, UnitPrice, CategoryID from Products";
            adapter = new SqlDataAdapter(query, _connString);
            productTable = new DataTable();
            adapter.Fill(productTable);
            commandBuilder = new SqlCommandBuilder(adapter);
        }

        public List<Product> GetProducts(GetOrSearchProducts getOrSearchProducts, int categoryID = 0)
        {
            productTable.Clear();
            adapter.Fill(productTable);
            List<Product> products = new List<Product>();
            switch (getOrSearchProducts)
            {
                case GetOrSearchProducts.Get:
                    foreach (DataRow item in productTable.Rows)
                    {
                        products.Add(new Product()
                        {
                            ProductID = Convert.ToInt32(item[0]),
                            ProductName = item[1].ToString(),
                            UnitPrice = Convert.ToDecimal(item[2]),
                            CategoryID = Convert.ToInt32(item[3])
                        });
                    }
                    break;

                case GetOrSearchProducts.Search:
                    DataRow[] dataRows = productTable.Select($"CategoryID = {categoryID}");
                    foreach (DataRow item in dataRows)
                    {
                        products.Add(new Product()
                        {
                            ProductID = Convert.ToInt32(item[0]),
                            ProductName = item[1].ToString(),
                            UnitPrice = Convert.ToDecimal(item[2]),
                            CategoryID = Convert.ToInt32(item[3])
                        });
                    }
                    break;
            }
            return products;
        }
    }
}
