using GildedRose.Items;
using System.Collections.Generic;

namespace GildedRose
{
    public class Shop
    {
        public IList<Item> itemList { get; private set; }

        public Shop(IList<Item> itemList){
            this.itemList = itemList;
        }

        public void UpdateQuality(){
            foreach(Item item in this.itemList){
                item.Update();
            }
        }
    }
}