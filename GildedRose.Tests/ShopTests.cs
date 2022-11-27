using System.Collections.Generic;
using GildedRose.Items;
using GildedRose.ItemsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ShopTests
    {
        public Shop shop;
        public ItemsGateway repository;
        [TestInitialize]
        public void Setup(){
            this.shop = new Shop(repository);
            this.shop.UpdateQuality();
        }

        [TestMethod]
        public void Should_UpdateItemProperties(){
            Assert.AreEqual(9, this.repository.GetInventory()[0].sellIn);
            Assert.AreEqual(7, this.repository.GetInventory()[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration(){
            Assert.AreEqual(6, this.repository.GetInventory()[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality(){
            Assert.AreEqual(0, this.repository.GetInventory()[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality(){
            Assert.AreEqual(5, this.repository.GetInventory()[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityOverFifty(){
            Assert.AreEqual(50, this.repository.GetInventory()[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties(){
            Assert.AreEqual(5, this.repository.GetInventory()[5].sellIn);
            Assert.AreEqual(80, this.repository.GetInventory()[5].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQuality(){
            Assert.AreEqual(11, this.repository.GetInventory()[6].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoTenDaysBefore(){
            Assert.AreEqual(12, this.repository.GetInventory()[7].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByThreeFiveDaysBefore(){
            Assert.AreEqual(13, this.repository.GetInventory()[8].quality);
        }

        [TestMethod]
        public void Should_SetBackstagePassQualityToZeroAfterEvent(){
            Assert.AreEqual(0, this.repository.GetInventory()[9].quality);
        }

        [TestMethod]
        public void Should_DecreaseConjuredItemsTwiceAsFastAsGenericItems(){
            Assert.AreEqual(6, this.repository.GetInventory()[10].quality);
        }

    }
}