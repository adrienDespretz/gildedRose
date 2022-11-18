using GildedRose.Items;
using GildedRose.ItemsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.ItemsRepository
{
    public class InMemoryItemsRepository:ItemRepository
    {
        private List<Item> itemsList = new List<Item>(){
            new GenericItem("Classic", 10, 8, 4.5),
            new GenericItem("Classic", -1, 8,5.5),
            new GenericItem("Classic", -1, 1,6.5),
            new AgingItem("Aged Brie", 5, 4,7.5),
            new AgingItem("Aged Brie", 5, 50,8.5),
            new LegendaryItem("Sulfuras", 5, 80,9.5),
            new EventItem("Backstage Pass", 15, 10,10.5),
            new EventItem("Backstage Pass", 10, 10,11.5),
            new EventItem("Backstage Pass", 5, 10,12.5),
            new EventItem("Backstage Pass", 0, 10,13.5),
            new ConjuredItem("Classic", 10, 8,14.5),
        };


        public void SaveInventory(List<Item> itemList)
        {
            foreach (Item item in itemList)
            {
                itemsList.Add(item);
            }

        }
        public List<Item> GetInventory()
        {
            return itemsList.ToList();
        }

        public Item FindItem(string type, int quality)
        {
            return itemsList.ToList().Where(x => x.quality == quality && x.name == type).FirstOrDefault();
        }

    }
}
