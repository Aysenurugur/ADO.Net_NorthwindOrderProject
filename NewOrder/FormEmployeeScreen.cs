using NewOrder.Entities;
using NewOrder.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewOrder
{
    public partial class FormEmployeeScreen : Form
    {
        public FormEmployeeScreen(Employee newEmployee)
        {
            InitializeComponent();
            orderDetailManagement = new OrderDetailManagement();
            orderManagement = new OrderManagement();
            employee = newEmployee;
        }
        OrderDetailManagement orderDetailManagement;
        OrderManagement orderManagement;
        Employee employee;

        private void FormEmployeeScreen_Load(object sender, EventArgs e)
        {
            foreach (OrderDetail od in orderDetailManagement.GetUnsignedOrders())
            {
                ListViewItem lvi = new ListViewItem(od.CustomerID);
                lvi.SubItems.Add(od.CustomerCompanyName);
                lvi.SubItems.Add(od.ContactTitle);
                lvi.SubItems.Add(od.OrderDate.ToString());
                lvi.SubItems.Add(od.ProductName);
                lvi.SubItems.Add(od.Quantity.ToString());
                lvi.SubItems.Add(od.TotalPrice.ToString());

                lviUnsignedOrders.Items.Add(lvi);
                lviUnsignedOrders.Tag = od.OrderID;
            }
        }

        private void lviUnsignedOrders_DoubleClick(object sender, EventArgs e)
        {
            int selectedOrder = (int)lviUnsignedOrders.Tag;

            foreach (OrderDetail item in orderDetailManagement.GetUnsignedOrders())
            {
                if (item.OrderID == selectedOrder)
                {
                    orderManagement.UpdateOrders(item, employee.EmployeeID, DateTime.Now);
                }
            }

            lviUnsignedOrders.SelectedItems[0].Remove();
            MessageBox.Show("Sipariş onaylandı.");
        }
    }
}
