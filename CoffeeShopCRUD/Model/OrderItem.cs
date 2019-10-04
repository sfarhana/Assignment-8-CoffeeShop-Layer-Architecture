using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopCRUD.Model
{
    public class OrderItem
    {
        public int OrderID{get; set;}	
        public int CustID{get; set;}
        public int ItemID{get; set;}	
        public int Quantity{get; set;}
        public double TotalPrice { get; set; }
		
    }

}
