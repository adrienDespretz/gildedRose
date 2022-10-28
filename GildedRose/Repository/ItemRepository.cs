using System.Collections.Generic;
using System.Linq;
using GildedRose.Items;

namespace GildedRose.ItemsRepository
{
    public interface ItemRepository
    {
        protected void SaveInventory(List<Item> itemList);
        protected List<Item> GetInventory();
        protected Item FindItem(string type, int quality);
    }
}
