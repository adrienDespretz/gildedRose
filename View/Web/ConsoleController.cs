using GildedRose.Appli;
using GildedRose.Items;
using System;
using System.Collections.Generic;

namespace ConsoleView.Web
{
    public class ConsoleController
    {
        private readonly ShopInputBoudary shopInputBoudary = new ShopInteractor();

        public ConsoleController( )
        {
           
        }
        public int UpdateInventory()
        {
            return shopInputBoudary.UpdateInventory();
        }

        public int SellItem(SellItemRequest request)
        {
            return shopInputBoudary.SellItem(request);
        }

        public Item LaunchAunction()
        {
            return shopInputBoudary.LaunchAunction();  
        }

        public double DoBidAunction(LaunchAunctionRequest launchAunction)
        {
            return shopInputBoudary.DoBidAunction(launchAunction);
        }
    }
}