using System.Collections.Generic;
using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ShopTests
    {
        public Shop shop;
        private List<Item> itemList = new List<Item>(){
            new Item("Classic", 10, 8),
            new Item("Classic", -1, 8),
            new Item("Classic", -1, 1),
            new Item("Aged Brie", 5, 4),
            new Item("Aged Brie", 5, 50),
            new Item("Sulfuras", 5, 80),
        };

        [TestInitialize]
        public void Setup(){
            this.shop = new Shop(itemList);
        }

        [TestMethod]
        public void Should_HaveSellIn(){
            Assert.AreEqual(10, this.shop.itemList[0].sellIn);
        }

        [TestMethod]
        public void Should_HaveQuality(){
            Assert.AreEqual(8, this.shop.itemList[0].quality);
        }

        [TestMethod]
        public void Should_UpdateItemProperties(){
            this.shop.UpdateQuality();
            Assert.AreEqual(9, this.shop.itemList[0].sellIn);
            Assert.AreEqual(7, this.shop.itemList[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration(){
            this.shop.UpdateQuality();
            Assert.AreEqual(6, this.shop.itemList[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality(){
            this.shop.UpdateQuality();
            Assert.AreEqual(0, this.shop.itemList[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality(){
            this.shop.UpdateQuality();
            Assert.AreEqual(5, this.shop.itemList[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityOverFifty(){
            this.shop.UpdateQuality();
            Assert.AreEqual(50, this.shop.itemList[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties(){
            this.shop.UpdateQuality();
            Assert.AreEqual(5, this.shop.itemList[5].sellIn);
            Assert.AreEqual(80, this.shop.itemList[5].quality);
        }
    }
}