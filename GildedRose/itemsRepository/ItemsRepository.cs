using System.Collections.Generic;
using GildedRose.Items;

namespace GildedRose.ItemsRepository
{
    public abstract class ItemsRepository
    {
        public List<Item> itemList = new List<Item>();
        
        protected List<Item> GetInventory(){
            return this.itemList;
        }

        protected void SaveInventory(List<Item> itemList){
            foreach(Item item in itemList){
                this.itemList.Add(item);
            }
        }
    }
}