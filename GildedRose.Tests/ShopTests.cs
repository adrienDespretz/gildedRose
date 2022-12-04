using System.Collections.Generic;
using GildedRose.Appli;
using GildedRose.Items;
using GildedRose.ItemsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ShopTests
    {
        public ShopInteractor shop;
        public ItemsGateway itemGateway;
        [TestInitialize]
        public void Setup(){
            this.shop = new ShopInteractor();
            this.shop.UpdateInventory();

            this.itemGateway = new InMemoryItemsRepository();
        }

        [TestMethod]
        public void Should_UpdateItemProperties(){
            Assert.AreEqual(9, this.shop.GetInventory()[0].sellIn);
            Assert.AreEqual(7, this.shop.GetInventory()[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration(){
            Assert.AreEqual(6, this.shop.GetInventory()[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality(){
            Assert.AreEqual(0, this.shop.GetInventory()[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality(){
            Assert.AreEqual(5, this.shop.GetInventory()[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityOverFifty(){
            Assert.AreEqual(50, this.shop.GetInventory()[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties(){
            Assert.AreEqual(5, this.shop.GetInventory()[5].sellIn);
            Assert.AreEqual(80, this.shop.GetInventory()[5].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQuality(){
            Assert.AreEqual(11, this.shop.GetInventory()[6].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoTenDaysBefore(){
            Assert.AreEqual(12, this.shop.GetInventory()[7].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByThreeFiveDaysBefore(){
            Assert.AreEqual(13, this.shop.GetInventory()[8].quality);
        }

        [TestMethod]
        public void Should_SetBackstagePassQualityToZeroAfterEvent(){
            Assert.AreEqual(0, this.shop.GetInventory()[9].quality);
        }

        [TestMethod]
        public void Should_DecreaseConjuredItemsTwiceAsFastAsGenericItems(){
            Assert.AreEqual(6, this.shop.GetInventory()[10].quality);
        }

        [TestMethod]
        public void Should_SaveInventory(){
            itemGateway.SaveInventory(this.shop.GetInventory());
            CollectionAssert.AreEqual(this.shop.GetInventory(), itemGateway.GetInventory());
        }

    }
}