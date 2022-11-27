using GildedRose.ItemsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class ShopInteractor
    {
        public ItemsGateway repository = new InMemoryItemsRepository();

        public ShopInteractor(ItemsGateway repository)
        {
            this.repository = repository;
        }

    }
}
