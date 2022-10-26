namespace GildedRose.Items
{
    public abstract class Item
    {
        public string name { get; protected set; }
        public int sellIn { get; protected set; }
        public int quality { get; protected set; }

        public Item(string name, int sellIn, int quality)
        {
            this.name = name;
            this.sellIn = sellIn;
            this.quality = quality;
        }

        public abstract void Update();

        protected void FloorQualityToZero()
        {
            if (this.quality < 0)
            {
                this.quality = 0;
            }
        }

        protected void TopQualityToFifty()
        {
            if (this.quality > 50)
            {
                this.quality = 50;
            }
        }
    }
}