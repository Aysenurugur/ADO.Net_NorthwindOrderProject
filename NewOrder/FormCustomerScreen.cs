using NewOrder.Entities;
using NewOrder.Enums;
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
    public partial class FormCustomerScreen : Form
    {
        CategoryManagement categoryManagement;
        ProductManagement productManagement;
        OrderManagement orderManagement;
        Customer newCustomer;
        OrderDetailManagement orderDetailManagement;

        public FormCustomerScreen(Customer customer)
        {
            InitializeComponent();
            categoryManagement = new CategoryManagement();
            productManagement = new ProductManagement();
            orderManagement = new OrderManagement();
            orderDetailManagement = new OrderDetailManagement();

            newCustomer = customer;
            grpCustomerScreen.Text = customer.ContactName;
        }
        private void FormCustomerScreen_Load(object sender, EventArgs e)
        {
            cbCategories.ValueMember = "CategoryID";
            cbCategories.DisplayMember = "Category";
            cbCategories.DataSource = categoryManagement.GetCategories();

            CreateFlowLayoutPanels(productManagement.GetProducts(GetOrSearchProducts.Get));
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryID = (int)cbCategories.SelectedValue;
            CreateFlowLayoutPanels(productManagement.GetProducts(GetOrSearchProducts.Search, categoryID));
        }

        private void CreateFlowLayoutPanels(List<Product> products)
        {
            flpProducts.Controls.Clear();
            foreach (Product item in products)
            {
                FlowLayoutPanel panel = new FlowLayoutPanel();
                Label productName = new Label();
                Label quantity = new Label();
                NumericUpDown nudQuantity = new NumericUpDown();
                Label price = new Label();
                Label unitPrice = new Label();
                Button btnAddOrder = new Button();

                panel.Size = new Size(250, 160);
                panel.BorderStyle = BorderStyle.Fixed3D;
                panel.BackColor = Color.Aquamarine;
                panel.Controls.Add(productName);
                panel.Controls.Add(quantity);
                panel.Controls.Add(nudQuantity);
                panel.Controls.Add(price);
                panel.Controls.Add(unitPrice);
                panel.Controls.Add(btnAddOrder);

                productName.Text = item.ProductName;
                productName.AutoSize = false;
                productName.Size = new Size(143, 36);
                quantity.Text = "Adet : ";
                price.Text = "Fiyat : ";
                unitPrice.Text = item.UnitPrice.ToString() + "$";
                nudQuantity.Value = 0;
                nudQuantity.Minimum = 0;
                btnAddOrder.Text = "Sipariş Ver";
                btnAddOrder.Size = new Size(223, 42);
                btnAddOrder.BackColor = Color.White;
                btnAddOrder.Click += BtnAddOrder_Click;
                nudQuantity.ValueChanged += NudQuantity_ValueChanged;

                flpProducts.Controls.Add(panel);

                btnAddOrder.Tag = item;
                nudQuantity.Tag = item;

            }
        }

        Product product;
        int quantity = 0;
        bool nudChangedControl = false;
        private void NudQuantity_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudQuantity = (NumericUpDown)sender;
            quantity = Convert.ToInt32(nudQuantity.Value);
            product = (Product)nudQuantity.Tag;
            nudChangedControl = true;
        }

        Product newProduct;
        private void BtnAddOrder_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            newProduct = (Product)btn.Tag;
            if (nudChangedControl)
            {
                if (product.ProductID == newProduct.ProductID)
                {
                    newProduct = product;
                    Order order = new Order()
                    {
                        CustomerID = newCustomer.CustomerID,
                        OrderDate = DateTime.Now,
                        Quantity = quantity,
                        TotalPrice = quantity * product.UnitPrice
                    };

                    orderManagement.InsertIntoOrders(order);
                    orderDetailManagement.InsertIntoOrderDetails(order, newProduct);

                    MessageBox.Show("Sipariş alındı.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen adet giriniz.");
            }
            nudChangedControl = false;
        }
    }
}
