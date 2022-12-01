using GildedRose.Items;
using GildedRose.ItemsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Appli
{
    public interface ShopInputBoudary
    {
        public int SellItem(SellItemRequest request);
        public int UpdateInventory();
        public Item LaunchAunction();
        public double DoBidAunction(LaunchAunctionRequest launchAunction);
    }
}
