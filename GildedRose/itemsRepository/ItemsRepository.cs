using System.Collections.Generic;
using System.Linq;
using GildedRose.Items;

namespace GildedRose.ItemsRepository
{
    public abstract class ItemsRepository
    {
        private readonly ItemContext _context;

        public ItemsRepository(ItemContext context)
        {
            _context = context;
        }

        public List<Item> itemList = new List<Item>();
        
        protected List<Item> GetInventory(){
            return _context.Items.ToList();
        }

        protected void SaveInventory(List<Item> itemList){
            foreach(Item item in itemList){
                _context.Items.Add(item);
            }
            _context.SaveChanges();

        }
    }
}