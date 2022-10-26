using System.Collections.Generic;

namespace GildedRose
{
    public class Shop
    {
        public IList<Item> itemList { get; }

        public Shop(){
            this.itemList = new List<Item>();
        }

        public void UpdateQuality(){

        }
    }
}