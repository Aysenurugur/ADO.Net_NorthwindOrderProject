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
    class EmployeeManagement
    {        
        string _connString;
        SqlDataAdapter adapter;
        DataTable employeeTable;
        SqlCommandBuilder commandBuilder;

        public EmployeeManagement()
        {
            _connString = ConfigurationManager.ConnectionStrings["_connectionString"].ToString();
            string query = "select EmployeeID, CONCAT(FirstName,'.',LastName) [Username], CONCAT(Year(BirthDate),REVERSE(City)) [Password] from Employees";
            adapter = new SqlDataAdapter(query, _connString);
            employeeTable = new DataTable();
            adapter.Fill(employeeTable);
            commandBuilder = new SqlCommandBuilder(adapter);
        }

        public Employee GetEmployeeLoginInfo(string username, string password)
        {
            Employee employee = null;
            employeeTable.Clear();
            adapter.Fill(employeeTable);

            DataRow[] rows = employeeTable.Select($"Username = '{username}' AND Password = '{password}'");
            if (rows.Length > 0)
            {
                foreach (DataRow item in rows)
                {
                    employee = new Employee()
                    {
                        EmployeeID = int.Parse(item[0].ToString()),
                        UserName = item[1].ToString(),
                        Password = item[2].ToString()
                    };
                }
                return employee;
            }
            else
                throw new Exception("Girdiğiniz bilgileri kontrol edin.");
        }
    }
}
