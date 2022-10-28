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
        private List<Item> itemList = new List<Item>(){
            new GenericItem("Classic", 10, 8),
            new GenericItem("Classic", -1, 8),
            new GenericItem("Classic", -1, 1),
            new AgingItem("Aged Brie", 5, 4),
            new AgingItem("Aged Brie", 5, 50),
            new LegendaryItem("Sulfuras", 5, 80),
            new EventItem("Backstage Pass", 15, 10),
            new EventItem("Backstage Pass", 10, 10),
            new EventItem("Backstage Pass", 5, 10),
            new EventItem("Backstage Pass", 0, 10),
            new ConjuredItem("Classic", 10, 8),
        };

        [TestInitialize]
        public void Setup(){
            this.shop = new Shop(itemList);
            this.shop.UpdateQuality();
        }

        [TestMethod]
        public void Should_UpdateItemProperties(){
            Assert.AreEqual(9, this.shop.itemList[0].sellIn);
            Assert.AreEqual(7, this.shop.itemList[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration(){
            Assert.AreEqual(6, this.shop.itemList[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality(){
            Assert.AreEqual(0, this.shop.itemList[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality(){
            Assert.AreEqual(5, this.shop.itemList[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityOverFifty(){
            Assert.AreEqual(50, this.shop.itemList[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties(){
            Assert.AreEqual(5, this.shop.itemList[5].sellIn);
            Assert.AreEqual(80, this.shop.itemList[5].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQuality(){
            Assert.AreEqual(11, this.shop.itemList[6].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoTenDaysBefore(){
            Assert.AreEqual(12, this.shop.itemList[7].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByThreeFiveDaysBefore(){
            Assert.AreEqual(13, this.shop.itemList[8].quality);
        }

        [TestMethod]
        public void Should_SetBackstagePassQualityToZeroAfterEvent(){
            Assert.AreEqual(0, this.shop.itemList[9].quality);
        }

        [TestMethod]
        public void Should_DecreaseConjuredItemsTwiceAsFastAsGenericItems(){
            Assert.AreEqual(6, this.shop.itemList[10].quality);
        }

    }
}