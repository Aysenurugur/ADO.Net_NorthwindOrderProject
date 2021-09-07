using NewOrder.Enums;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEmployeeSignIn_Click(object sender, EventArgs e)
        {
            FormLoginScreen formLoginScreen = new FormLoginScreen(CustomerOrEmployee.Employee);
            this.Hide();
            formLoginScreen.ShowDialog();
            this.Show();
        }

        private void btnCustomerSignIn_Click(object sender, EventArgs e)
        {
            FormLoginScreen formLoginScreen = new FormLoginScreen(CustomerOrEmployee.Customer);
            this.Hide();
            formLoginScreen.ShowDialog();
            this.Show();
        }
    }
}
