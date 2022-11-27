using System.Collections.Generic;
using System.Linq;
using GildedRose.Items;

namespace GildedRose.ItemsRepository
{
    public interface ItemsGateway
    {
        public void SaveInventory(List<Item> itemList);
        public List<Item> GetInventory();
        public Item FindItem(string type, int quality);
    }
}
