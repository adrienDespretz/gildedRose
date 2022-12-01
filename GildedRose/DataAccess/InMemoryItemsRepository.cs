using GildedRose.Appli;
using GildedRose.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GildedRose.ItemsRepository
{
    public class InMemoryItemsRepository:ItemsGateway
    {
        private List<Item> itemsList = new List<Item>(){
            new GenericItem("Classic", 10, 8, 4,"Attack +10"),
            new GenericItem("Classic", -1, 8,5,"Attack +5"),
            new GenericItem("Classic", -1, 1,6,"Defense +10"),
            new AgingItem("Aged Brie", 5, 4,7),
            new AgingItem("Aged Brie", 5, 50,8),
            new LegendaryItem("Sulfuras", 5, 80,9,"Guérison +7"),
            new EventItem("Backstage Pass", 15, 10,10),
            new EventItem("Backstage Pass", 10, 10,11),
            new EventItem("Backstage Pass", 5, 10,12),
            new EventItem("Backstage Pass", 0, 10,13),
            new ConjuredItem("Classic", 10, 8,14,"Resistance +15"),
        };

        public void SaveInventory(List<Item> itemList)
        {
            itemsList = itemList.ToList();
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
