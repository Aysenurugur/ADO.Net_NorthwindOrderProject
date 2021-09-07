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
    public partial class FormLoginScreen : Form
    {
        CustomerOrEmployee personType;
        public FormLoginScreen(CustomerOrEmployee customerOrEmployee)
        {
            InitializeComponent();
            personType = customerOrEmployee;
        }

        private void FormLoginScreen_Load(object sender, EventArgs e)
        {
            switch (personType)
            {
                case CustomerOrEmployee.Customer:
                    grpLogin.Text = "Müşteri Giriş Ekranı";
                    btnSignIn.Text = "Müşteri Girişi";
                    lblUsername.Text = "Şirket ID :";
                    lblPassword.Text = "Şifre :";
                    break;
                case CustomerOrEmployee.Employee:
                    grpLogin.Text = "Çalışan Giriş Ekranı";
                    btnSignIn.Text = "Çalışan Girişi";
                    lblUsername.Text = "Kullanıcı Adı :";
                    lblPassword.Text = "Şifre :";
                    break;
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e) //selectle yap
        {
            try
            {
                switch (personType)
                {
                    case CustomerOrEmployee.Customer:
                        CustomerManagement customerManagement = new CustomerManagement();
                        Customer customer = customerManagement.GetCustomerLoginInfo(txtUsername.Text, txtPassword.Text);
                        FormCustomerScreen formCustomerScreen = new FormCustomerScreen(customer);
                        this.Hide();
                        formCustomerScreen.ShowDialog();
                        this.Show();

                        break;
                    case CustomerOrEmployee.Employee:
                        EmployeeManagement employeeManagement = new EmployeeManagement();
                        Employee employee = employeeManagement.GetEmployeeLoginInfo(txtUsername.Text, txtPassword.Text);
                        FormEmployeeScreen formEmployeeScreen = new FormEmployeeScreen(employee);
                        this.Hide();
                        formEmployeeScreen.ShowDialog();
                        this.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
