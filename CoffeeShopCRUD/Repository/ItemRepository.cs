using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CoffeeShopCRUD.Model;

namespace CoffeeShopCRUD.Repository
{
    public class ItemRepository
    {

        public bool IsItemInDB(string itm)
        {
            try
            {
                string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                sqlconnection.Open();

                string command = @"select * from Item where ItemName='" + itm + "'";
                SqlCommand sqlcommand = new SqlCommand(command, sqlconnection);
                SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcommand);
                DataTable datatable = new DataTable();
                sqladapter.Fill(datatable);

                sqlconnection.Close();

                if (datatable.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool InsertItem(Item item)
        {
            try
            {
                string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                sqlconnection.Open();

                string CommandString = @"Insert into Item(ItemName,ItemPrice) values
                                  ('" + item.ItemName + "'," + item.ItemPrice.ToString() + ")";
                SqlCommand sqlcommand = new SqlCommand(CommandString, sqlconnection);

                int isExecuted = sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
                if (isExecuted > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception)
            {

                throw;//MessageBox.Show("Insertion Error");
            }

        }

        public DataTable ShowItem()
        {
            try
            {
                string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                sqlconnection.Open();

                string CommandString = @"Select * from Item";
                SqlCommand sqlcommand = new SqlCommand(CommandString, sqlconnection);
                SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcommand);
                DataTable datatable = new DataTable();

                sqladapter.Fill(datatable);
                sqlconnection.Close();
                if (datatable.Rows.Count > 0)
                {
                    return datatable;
                }
                else
                {
                    return null;
                   // MessageBox.Show("No data is stored in Item Table ");
                }
            }
            catch (Exception)
            {

                throw;//MessageBox.Show("Error on Show all Items");
            }

        }

        public bool UpdateItem(Item item)
        {
            try
            {
                string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                sqlconnection.Open();

                string CommandString = @"Update Item set ItemName='" + item.ItemName +
                                       "', ItemPrice='" + item.ItemPrice.ToString() + "' where ItemID=" + item.ItemID;

                SqlCommand sqlcommand = new SqlCommand(CommandString, sqlconnection);

                int isUpdated = sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
                if (isUpdated > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;//MessageBox.Show("Error on Update");
            }

        }

        public DataTable SearchItem(string Searchname)
        {
            try
            {
                
                string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                sqlconnection.Open();

                string CommandString = @"select * from Item where ItemName='" + Searchname + "'";
                SqlCommand sqlcommand = new SqlCommand(CommandString, sqlconnection);

                SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcommand);
                DataTable datatable = new DataTable();
                sqladapter.Fill(datatable);
                sqlconnection.Close();
                if (datatable.Rows.Count > 0)
                {
                   return datatable;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;//MessageBox.Show("Error on Search Item");
            }

        }
    public bool DeleteItem(string searchname)
        {
            try
            {
                string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                sqlconnection.Open();

                string CommandString = @"Delete from Item where ItemName='" + searchname + "'";
                SqlCommand sqlcommand = new SqlCommand(CommandString, sqlconnection);

                int isDeleted = sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
                if (isDeleted > 0)
                {
                    return true; 
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

       

    }
}
