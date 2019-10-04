using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopCRUD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomer Customer = new FrmCustomer();
            Customer.Show();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            FrmItem Item = new FrmItem();
            Item.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Order Order = new Order();
            Order.Show();
        }
    }
}
