using System.Collections.Generic;
using GildedRose.Items;

namespace GildedRose.ItemsRepository
{
    public abstract class ItemsRepository
    {
        public List<Item> itemList = new List<Item>();
        
        protected List<Item> GetInventory(){
            return itemList;
        }
    }
}