using System.Collections.Generic;

namespace GildedRose
{
    public class Item
    {
        public int sellIn { get; private set; }
        public int quality { get; private set; }

        public Item(int sellIn, int quality)
        {
            this.sellIn = sellIn;
            this.quality = quality;
        }

        public void DecreaseSellIn(){
            this.sellIn--;
        }

        public void DecreaseQuality(){
            if(this.sellIn < 0){
                this.quality--;
            }
            this.quality--;
        }
    }
}