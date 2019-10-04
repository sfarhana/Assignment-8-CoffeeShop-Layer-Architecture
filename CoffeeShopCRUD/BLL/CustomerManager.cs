using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopCRUD.Repository;
using System.Data;
using CoffeeShopCRUD.Model;


namespace CoffeeShopCRUD.BLL
{
    public class CustomerManager
    {
        CustomerRepository _CustomerRepository = new CustomerRepository();
        public bool IsCustomerInDB(string nm)
        {
            return _CustomerRepository.IsCustomerInDB(nm);
        }

        public bool InsertCustomer(Customer Cust)
        {
            return _CustomerRepository.InsertCustomer(Cust);
        }

        public DataTable ShowCustomer()
        {
            return _CustomerRepository.ShowCustomer();
        }

        public bool DeleteCustomer(string SearchName)
        {
            return _CustomerRepository.DeleteCustomer(SearchName);
        }

        public DataTable SearchCustomer(string SearchName)
        {
            return _CustomerRepository.SearchCustomer(SearchName);
        }

        public bool UpdateCustomer(string cname, string contact, string address, string searchname)
        {
            return _CustomerRepository.UpdateCustomer(cname, contact, address, searchname);
        }

        public bool IsUniqueContact(string Contact)
        {
            return _CustomerRepository.IsUniqueContact(Contact);
        }

    }
}
