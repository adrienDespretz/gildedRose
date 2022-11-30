using GildedRose.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Appli
{
    public interface ShopOutputBoundary
    {
        public void DisplayInventory(List<ItemResponse> inventory);

        public void DisplayBalance(int balance);
    }
}
