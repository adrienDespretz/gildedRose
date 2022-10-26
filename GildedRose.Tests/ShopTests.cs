﻿using System.Collections.Generic;
using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ShopTests
    {
        public Shop shop;
        private List<Item> itemList = new List<Item>(){
            new Item(10, 8),
        };

        [TestInitialize]
        public void Setup(){
            this.shop = new Shop(itemList);
        }

        [TestMethod]
        public void Should_UpdateQuality(){
            this.shop.UpdateQuality();
        }

        [TestMethod]
        public void Should_HaveSellIn(){
            Assert.AreEqual(10, this.shop.itemList[0].sellIn);
        }

        [TestMethod]
        public void Should_HaveQuality(){
            Assert.AreEqual(8, this.shop.itemList[0].quality);
        }
    }
}