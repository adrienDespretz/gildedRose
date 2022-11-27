using GildedRose.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class ShopOutputBoundary
    {
        private ShopInteractor ViewBoundary;
        public void DisplayInventory(List<ItemResponse> inventory)
        {
            foreach (var item in inventory)
            {
                Console.WriteLine( " \t/ Sell in : " + item.sellIn + " \t/ Qualité : " + item.quality + " \t/ Prix : " + item.value);
            }

        }
        public void DisplayBalance(int balance)
        {
            Console.WriteLine("Votre solde : " + balance);
        }
    }
}
