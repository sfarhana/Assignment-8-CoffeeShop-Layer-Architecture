using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CoffeeShopCRUD.BLL;
using CoffeeShopCRUD.Model;

namespace CoffeeShopCRUD
{
    public partial class FrmItem : Form
    {
        ItemManager _itemManager = new ItemManager();
        int ItemId=0;
        public FrmItem()
        {
            InitializeComponent();
        }
   

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            if (string.IsNullOrEmpty(txtIname.Text))
            {
                MessageBox.Show("name field can not be empty");
                return;
            }
            if (string.IsNullOrEmpty(txtIprice.Text))
            {
                MessageBox.Show("Price field can not be empty");
                return;
            }
            bool isItem = _itemManager.IsItemInDB(txtIname.Text);

            if (isItem == true)
            {
                MessageBox.Show(txtIname.Text + "already exsists");
                return;
            }
            else
            {
                item.ItemName=txtIname.Text;
                item.ItemPrice=Convert.ToDouble(txtIprice.Text);
                bool insertSuccess = _itemManager.InsertItem(item);
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = _itemManager.ShowItem();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Item item = new Item();
            try
            {
                item.ItemID = ItemId;
                item.ItemName = txtIname.Text;
                item.ItemPrice = Convert.ToDouble(txtIprice.Text);
                bool updateSuccess = _itemManager.UpdateItem(item);
                if (updateSuccess == true)
                {
                    MessageBox.Show("Update Succsecfull");
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
               
            }
            //catch (SqlException ex)
            //{

            //    MessageBox.Show(ex.Message.ToString());
            //}
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtIname.Text = "";
            txtIprice.Text = "";
            DataTable resultdatatable = new DataTable();
            resultdatatable = _itemManager.SearchItem(txtSearch.Text);
            if (resultdatatable != null)
                dataGridView.DataSource = resultdatatable;
            else
                MessageBox.Show("Search Failed:Data Not Found");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool deleteSuccess = _itemManager.DeleteItem(txtSearch.Text); 
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
                MessageBox.Show("Error on Deletion"+ex.Message.ToString());
            }
            
           
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow row=dataGridView.Rows[index];
            txtIname.Text = row.Cells[1].Value.ToString();
            txtIprice.Text = row.Cells[2].Value.ToString();
            ItemId = Convert.ToInt16( row.Cells[0].Value.ToString());
        }



    }
}
