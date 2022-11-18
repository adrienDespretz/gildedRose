using System.Collections.Generic;
using System.Linq;
using GildedRose.Items;
using GildedRose.ItemsRepository;

namespace GildedRose
{
    public class Shop
    {
        public IList<Item> itemList { get; private set; }
        public float balance { get; private set; }
        public FileItemsRepository fileItemsRepository { get; private set; }

        public Shop(IList<Item> itemList){
            this.itemList = itemList;
        }

        public void UpdateQuality(){
            foreach(Item item in this.itemList){
                item.Update();
            }
        }
        public void SellItem(string type , int quality)
        {
            var itemFind = fileItemsRepository.FindItem(type, quality);
            balance += itemFind.basePrice;
            itemList.Remove(itemFind);
        }
    }
}