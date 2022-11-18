using GildedRose.Items;
using GildedRose.ItemsRepository;
using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Shop
    {
        public double balance { get; private set; }
        public ItemRepository repository;

        public Shop(ItemRepository repository)
        {
            this.repository = repository;
        }

        public void UpdateQuality()
        {
            List<Item> itemList = this.repository.GetInventory();
            foreach (Item item in itemList)
            {
                item.Update();
            }
            this.repository.SaveInventory(itemList);
        }
        public void SellItem(string type, int quality)
        {
            var itemFind = repository.FindItem(type, quality);

            if (itemFind == null)
                throw new Exception("Item not found");

            List<Item> itemList = this.repository.GetInventory();
            itemList.Remove(itemFind);
            this.repository.SaveInventory(itemList);

            balance += itemFind.basePrice;

        }
        public double GetBalance()
        {
            return this.balance = balance;
        }
    }
}