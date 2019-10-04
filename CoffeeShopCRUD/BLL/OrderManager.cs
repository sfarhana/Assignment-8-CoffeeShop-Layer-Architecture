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
    public class OrderManager
    {
        OrderRepository _orderepository = new OrderRepository();

        public List<Customer> NameLoadOnCombo()
        {
            return _orderepository.NameLoadOnCombo();
        }
        public List<Item> ItemLoadOnCombo()
        {
            return _orderepository.ItemLoadOnCombo();
        }

        public bool InsertOrder(OrderItem OrderItem)
        {
            return _orderepository.InsertOrder(OrderItem);
        }

        public string UnitPriceFind(OrderItem OrderItem)
        {
            return _orderepository.UnitPriceFind(OrderItem);
        }

        public DataTable LoadDataOnGrid()
        {
            return _orderepository.LoadDataOnGrid();
        }


    }
}
