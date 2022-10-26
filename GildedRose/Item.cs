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

        public void DecreaseSellIn(){
            this.sellIn--;
        }

        public void DecreaseQuality(){
            if(this.name == "Aged Brie"){
                this.quality++;
            }else{
                if(this.sellIn < 0){
                    this.quality--;
                }
                this.quality--;
            }

            if(this.quality < 0){
                this.quality = 0;
            }
        }
    }
}