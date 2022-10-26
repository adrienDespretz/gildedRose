using System.Collections.Generic;

namespace GildedRose
{
    public class Item
    {
        public string name { get; private set; }
        public int sellIn { get; private set; }
        public int quality { get; private set; }

        public Item(string name, int sellIn, int quality)
        {
            this.name = name;
            this.sellIn = sellIn;
            this.quality = quality;
        }

        public void Update(){
            if(this.name == "Sulfuras"){
                return;
            }
            UpdateSellIn();
            UpdateQuality();
        }

        public void UpdateSellIn(){
            this.sellIn--;
        }

        public void UpdateQuality()
        {
            switch(this.name){
                case "Aged Brie" : UpdateAgingItemQuality(); break;
                default : UpdateGenericItemQuality(); break;
            }

            FloorQualityToZero();
            TopQualityToFifty();
        }

        private void UpdateGenericItemQuality()
        {
            if (this.sellIn < 0)
            {
                this.quality--;
            }
            this.quality--;
        }

        private void UpdateAgingItemQuality()
        {
            this.quality++;
        }

        private void FloorQualityToZero()
        {
            if (this.quality < 0)
            {
                this.quality = 0;
            }
        }

        private void TopQualityToFifty()
        {
            if (this.quality > 50)
            {
                this.quality = 50;
            }
        }
    }
}