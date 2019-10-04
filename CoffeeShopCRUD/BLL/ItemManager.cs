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
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();

        public bool IsItemInDB(string itm)
        {
            return _itemRepository.IsItemInDB(itm);
        }
        public bool InsertItem(Item item)
        {
            return _itemRepository.InsertItem(item);
        }
        public DataTable ShowItem()
        {
            return _itemRepository.ShowItem();
        }
        public bool UpdateItem(Item item)
        {
            return _itemRepository.UpdateItem(item);
        }
        public DataTable SearchItem(string Searchname)
        {
            return _itemRepository.SearchItem(Searchname);
        }
        public bool DeleteItem(string searchname)
        {
            return _itemRepository.DeleteItem(searchname);
        }
    }
}
