using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopCRUD.BLL;
using System.Data.SqlClient;
using System.Data;
using CoffeeShopCRUD.Model;

namespace CoffeeShopCRUD.Repository
{
    public class CustomerRepository
    {
       public bool IsCustomerInDB(string nm)
        {

            try
            {
                string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                sqlconnection.Open();

                string command = @"select * from Customer where CustName = '" + nm + "'";
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
            catch (SqlException)
            {
                throw;
            }
        }
       public bool IsUniqueContact(string Contact)
       {
           try
           {
               string connstring = @"server=FARHANAMOSTO-PC;database=CoffeeShopCRUD;Integrated security=true";
               SqlConnection conn = new SqlConnection(connstring);
               conn.Open();

               string cmdstring = @"select *  from Customer where Contact='" + Contact + "'";
               SqlCommand sqlcmd = new SqlCommand(cmdstring, conn);

               SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcmd);

               DataTable datatable = new DataTable();
               sqladapter.Fill(datatable);
               conn.Close();

               if (datatable.Rows.Count > 0)
               {
                   return true;
               }
               else
                   return false;

           }
           catch (Exception)
           {
               
               throw;
           }
           
       }

       public bool InsertCustomer(Customer Cust)
       {
           try
           {
               string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
               SqlConnection sqlconnection = new SqlConnection(ConnectionString);
               sqlconnection.Open();

               string CommandString = @"Insert into Customer(CustName,Contact,Address) values
                                   ('" + Cust.CustName + "','" + Cust.Contact + "','" + Cust.Address + "')";
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
               throw;
           }

       }

       public DataTable ShowCustomer()
       {
           try
           {
               string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
               SqlConnection sqlconnection = new SqlConnection(ConnectionString);
               sqlconnection.Open();

               string CommandString = @"Select * from Customer";
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
               throw;
              
           }
       }
       public bool DeleteCustomer(string SearchName)
       {
           try
           {
               string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
               SqlConnection sqlconnection = new SqlConnection(ConnectionString);
               sqlconnection.Open();

               string CommandString = @"Delete from Customer where CustName='" + SearchName + "'";
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

       public DataTable SearchCustomer(string SearchName)
       {
           try
           {
               string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
               SqlConnection sqlconnection = new SqlConnection(ConnectionString);
               sqlconnection.Open();

               string CommandString = @"select * from Customer where CustName = '" + SearchName + "'";
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
               throw;
               //MessageBox.Show("Error on Search Customer");
           }

       }

       public bool UpdateCustomer(string cname,string contact,string address,string searchname)
       {
           try
           {
               string ConnectionString = @"server=FARHANAMOSTO-PC;Database=CoffeeShopCRUD;Integrated Security=True";
               SqlConnection sqlconnection = new SqlConnection(ConnectionString);

               sqlconnection.Open();

               string CommandString = @"Update Customer set CustName ='" + cname + "', Contact = '" + contact +
                                      "', Address = '" + address + "' where CustName = '" + searchname + "'";
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


    }
}
