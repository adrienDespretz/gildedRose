using GildedRose.Appli;
using GildedRose.Items;
using System;
using System.Collections.Generic;

namespace ConsoleView.Web
{
    public class ConsoleController
    {
        private readonly ShopInputBoudary shopInputBoudary = new ShopInteractor();

        public ConsoleController()
        {

        }

        public void UpdateInventory()
        {
            shopInputBoudary.UpdateInventory();
        }

        public int SellItem(SellItemRequest request)
        {
            return shopInputBoudary.SellItem(request);
        }
    }
}