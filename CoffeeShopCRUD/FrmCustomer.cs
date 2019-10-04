using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using CoffeeShopCRUD.BLL;
using CoffeeShopCRUD.Model;

namespace CoffeeShopCRUD
{
    public partial class FrmCustomer : Form
    {
        CustomerManager _CustomerManager = new CustomerManager();
        public FrmCustomer()
        {
            InitializeComponent();
        }
                      
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtCname.Text))
                {
                    MessageBox.Show("name field can not be empty");
                    return;
                }

                bool isCus = _CustomerManager.IsCustomerInDB(txtCname.Text);
                if (isCus == true)
                {
                    MessageBox.Show("name already exsists");
                    return;
                }

                if (string.IsNullOrEmpty(txtContact.Text))
                {
                    MessageBox.Show("Contact field can not be empty");
                    return;
                }

                bool isContact = _CustomerManager.IsUniqueContact(txtContact.Text);
                if (isContact == true)
                {
                    MessageBox.Show("Contact must be unique,please put another contact");
                    return;
                }

              if(isCus==false)
                {
                    Customer Cust =new Customer();
                    Cust.CustName=txtCname.Text;
                    Cust.Contact=txtContact.Text;
                    Cust.Address=txtAddress.Text;

                    bool insertSuccess = _CustomerManager.InsertCustomer(Cust);
                    if (insertSuccess == true)
                    {
                        MessageBox.Show("Entry Saved");
                    }
                    else
                    {
                        MessageBox.Show("Not Saved");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insertion Error " + " Error Details : " + ex.Message.ToString());
            }
            

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.DataSource = _CustomerManager.ShowCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on Show all Customer"+ex.Message.ToString());
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool deleteSuccess = _CustomerManager.DeleteCustomer(txtSearch.Text);
                if (deleteSuccess == true)
                {
                    MessageBox.Show("Delete Succsecfully");
                }
                else
                {
                    MessageBox.Show("Delete Failed");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error on Deletion" + ex.Message.ToString());
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtCname.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            DataTable resultdatatable = new DataTable();
            resultdatatable=_CustomerManager.SearchCustomer(txtSearch.Text);
            if (resultdatatable!=null)
                dataGridView.DataSource = resultdatatable;
            else
                MessageBox.Show("Search Failed:Data Not Found");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool updateSuccess = _CustomerManager.UpdateCustomer(txtCname.Text, txtContact.Text, txtAddress.Text, txtSearch.Text);
            if (updateSuccess == true)
            {
                MessageBox.Show("Update Succsecfull");
            }
            else
            {
                MessageBox.Show("Update Failed");
            }
            
        }

                                
      }
}
