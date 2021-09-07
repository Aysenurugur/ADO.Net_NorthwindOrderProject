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
    class CategoryManagement
    {
        string _connString;
        SqlDataAdapter adapter;
        DataTable categoryTable;
        SqlCommandBuilder commandBuilder;

        public CategoryManagement()
        {
            _connString = ConfigurationManager.ConnectionStrings["_connectionString"].ToString();
            string query = "select CategoryID, CategoryName from Categories";
            adapter = new SqlDataAdapter(query, _connString);
            categoryTable = new DataTable();
            adapter.Fill(categoryTable);
            commandBuilder = new SqlCommandBuilder(adapter);
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            categoryTable.Clear();
            adapter.Fill(categoryTable);
            foreach (DataRow item in categoryTable.Rows)
            {
                categories.Add(new Category()
                {
                    CategoryID = Convert.ToInt32(item[0]),
                    CategoryName = item[1].ToString()
                });
            }
            return categories;
        }
    }
}
