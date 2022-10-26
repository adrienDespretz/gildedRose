﻿using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ShopTests
    {
        public Shop shop;

        [TestInitialize]
        public void Setup(){
            this.shop = new Shop();
        }

        [TestMethod]
        public void Should_UpdateQuality(){
            this.shop.UpdateQuality();
        }
    }
}