using GildedRose.Items;
using GildedRose.ItemsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class ShopInputBoudary:ShopInteractor
    {
        public ShopInputBoudary(ItemsGateway repository) : base(repository)
        {
        }

        public void UpdateInventory()
        {
            List<Item> itemList = this.repository.GetInventory();
            foreach (Item item in itemList)
            {
                item.Update();
            }
            this.repository.SaveInventory(itemList);
        }

        public void SellItem(SellItemRequest request)
        {
            var itemFind = repository.FindItem(request.type, request.quality);

            if (itemFind == null)
                throw new Exception("Item not found");

            List<Item> itemList = this.repository.GetInventory();
            itemList.Remove(itemFind);
            this.repository.SaveInventory(itemList);
            SendMail.SendNotif(itemFind.name);
            //balance += itemFind.basePrice;
        }

    }
}
