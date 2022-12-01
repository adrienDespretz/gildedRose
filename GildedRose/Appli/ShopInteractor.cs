using GildedRose.Items;
using GildedRose.ItemsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Appli
{
    public class ShopInteractor : ShopInputBoudary
    {
        private readonly ItemsGateway itemsGateway = new InMemoryItemsRepository();
        private readonly ShopOutputBoundary shopOutputBoundary;

        public ShopInteractor()
        {
        }

        public Item LaunchAunction()
        {
            var random = new Random();
            List<Item> itemList = itemsGateway.GetInventory();

            int index = random.Next(itemList.Count);
            Item item = itemList[index];

            return item;
        }
        public int SellItem(SellItemRequest request)
        {
            int balance = 0;
            var itemFind = itemsGateway.FindItem(request.type, request.quality);

            if (itemFind == null)
                throw new Exception("Item not found");

            List<Item> itemList = itemsGateway.GetInventory();
            itemList.Remove(itemFind);
            itemsGateway.SaveInventory(itemList);
            //SendMail.SendNotif(itemFind.name);
            balance += itemFind.basePrice;

            return balance;
        }

        public int UpdateInventory()
        {
            int RelicItemUpdate = 0;
            List<Item> itemList = itemsGateway.GetInventory();
            foreach (Item item in itemList)
            {
                if(item.name.ToLower() == "relicitem")
                {
                    item.Update();
                    RelicItemUpdate = item.basePrice;
                }
                else
                {
                    item.Update();
                }
            }
            itemsGateway.SaveInventory(itemList);
            return RelicItemUpdate;
        }

        public List<Item> GetInventory()
        {
            return itemsGateway.GetInventory();
        }

        public Item FindItem(string type, int quality)
        {
            return itemsGateway.FindItem(type, quality);
        }

        public double DoBidAunction(LaunchAunctionRequest launchAunction)
        {
            if(launchAunction.response.ToLower() == "oui")
            {
                launchAunction.BidPrice = launchAunction.BidPrice * 1.1;
            }

            return launchAunction.BidPrice;
        }


    }
}
