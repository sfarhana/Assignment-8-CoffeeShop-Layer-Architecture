using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CoffeeShopCRUD.BLL;
using CoffeeShopCRUD.Model;

namespace CoffeeShopCRUD.Repository
{
    public class OrderRepository
    {
        public List<Customer> NameLoadOnCombo()
        {
            List<Customer> CustList = new List<Customer>();
            try
            {
                string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                sqlconnection.Open();

                string CommandString = @"Select * from Customer";
                SqlCommand sqlcommand = new SqlCommand(CommandString, sqlconnection);
                SqlDataReader sdr = sqlcommand.ExecuteReader();
                
                
                while (sdr.Read())
                {
                    Customer c = new Customer();

                    c.CustID = Convert.ToInt16(sdr["CustID"].ToString());
                    c.CustName = sdr["CustName"].ToString();
                    c.Contact = sdr["Contact"].ToString();
                    c.Address = sdr["Address"].ToString();

                    CustList.Add(c);
                }
               
            }
            catch (Exception)
            {
                
                throw;
            }
            return CustList;
           
           }

        public List<Item> ItemLoadOnCombo()
        {
            List<Item> Items = new List<Item>();
            try
            {
                string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                sqlconnection.Open();

                string CommandString = @"Select * from Item";
                SqlCommand sqlcommand = new SqlCommand(CommandString, sqlconnection);
                SqlDataReader sdr = sqlcommand.ExecuteReader();
                while (sdr.Read())
                {
                    Item i = new Item();
                    i.ItemID = Convert.ToInt16(sdr["ItemID"].ToString());
                    i.ItemName = sdr["ItemName"].ToString();
                    i.ItemPrice = Convert.ToDouble(sdr["ItemPrice"].ToString());
                    Items.Add(i);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return Items;
            
            
        }

        public string UnitPriceFind(OrderItem OrderItem)
        {
            string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
            SqlConnection sqlconnection = new SqlConnection(ConnectionString);
            sqlconnection.Open();

            string CommandString = @"Select ItemPrice from Item where ItemID= " + OrderItem.ItemID;
            SqlCommand sqlcommand = new SqlCommand(CommandString, sqlconnection);
            SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcommand);
            DataTable datatable = new DataTable();
            sqladapter.Fill(datatable);
            sqlconnection.Close();

            if (datatable.Rows.Count > 0)
            {
                return datatable.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }

        }
        public bool InsertOrder(OrderItem OrderItem)
        {
            string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
            SqlConnection sqlconnection = new SqlConnection(ConnectionString);
            sqlconnection.Open();

            string CommandString = @"Insert into OrderItem (CustID,ItemID,Quantity,TotalPrice) values(" + OrderItem.CustID.ToString() + ", " + OrderItem.ItemID.ToString() + ", " + OrderItem.Quantity.ToString() +","+OrderItem.TotalPrice.ToString()+ ")";
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

        public DataTable LoadDataOnGrid()
        {
            string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
            SqlConnection sqlconnection = new SqlConnection(ConnectionString);
            sqlconnection.Open();

            string CommandString = @"select OrderID,CustName,ItemName,O.Quantity,I.ItemPrice,O.TotalPrice
                                  from OrderItem O left join Item I on O.ItemID=I.ItemID left join Customer C on O.CustID=C.CustID";
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
     

        
    }
}
