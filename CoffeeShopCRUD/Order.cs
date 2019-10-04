using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopCRUD.BLL;
using CoffeeShopCRUD.Model;

namespace CoffeeShopCRUD
{
    public partial class Order : Form
    {
        OrderManager _ordermanager = new OrderManager();
        public Order()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            //comboCustomer.ValueMember = "CustID";
            //comboCustomer.DisplayMember = "CustName";
            comboCustomer.DataSource = _ordermanager.NameLoadOnCombo();
            comboItem.DataSource = _ordermanager.ItemLoadOnCombo();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OrderItem OrderItem = new OrderItem();
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Please put a Quantity value");
                return;
            }
            
            int Quantity = Convert.ToInt16(txtQuantity.Text);
            int ItemID = Convert.ToInt16(comboItem.SelectedValue.ToString());
            int CustID = Convert.ToInt16(comboCustomer.SelectedValue.ToString());

            OrderItem.CustID = CustID;
            OrderItem.ItemID = ItemID;
            OrderItem.Quantity = Quantity;

            //Total price calculation
            string unitprice = _ordermanager.UnitPriceFind(OrderItem);
            double TotalPrice = Quantity * Convert.ToDouble(unitprice);

            OrderItem.TotalPrice = TotalPrice;
            txtTotal.Text = TotalPrice.ToString();
            
            bool saveres=_ordermanager.InsertOrder(OrderItem);
            if (saveres == true)
                MessageBox.Show("Your Order is saved");

            dataGridView.DataSource = _ordermanager.LoadDataOnGrid();

        }

    }
}
