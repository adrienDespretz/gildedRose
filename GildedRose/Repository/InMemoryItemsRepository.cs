using GildedRose.Items;
using GildedRose.ItemsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.itemsRepository
{
    public class InMemoryItemsRepository:ItemRepository
    {
        private readonly ItemContext _context;

        public InMemoryItemsRepository(ItemContext context)
        {
            _context = context;
        }

        public List<Item> itemList = new List<Item>();

        void ItemRepository.SaveInventory(List<Item> itemList)
        {
            foreach (Item item in itemList)
            {
                _context.Items.Add(item);
            }
            _context.SaveChanges();
        }

        List<Item> ItemRepository.GetInventory()
        {
            return _context.Items.ToList();
        }

        Item ItemRepository.FindItem(string type, int quality)
        {
            return _context.Items.ToList().Where(x => x.quality == quality && x.name == type).FirstOrDefault();
        }
    }
}
