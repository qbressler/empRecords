using FactoryForms.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryForms
{
    public partial class Form1 : Form
    {
        CustomerBase customer = null;
        public Form1()
        {
            InitializeComponent();
            customerComboBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetCustomer();
            try
            {
                customer.Validate();
                MessageBox.Show("Success");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void SetCustomer()
        {
            customer.CustomerAddress = addressTextBox.Text;
            customer.CustomerName = nameTextBox.Text;
        }

        private void customerComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            customer = Factory.CreateObj(customerComboBox.Text);
        }
    }
}
