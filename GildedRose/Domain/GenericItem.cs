namespace GildedRose.Items
{
    public class GenericItem : Item
    {
        public string attributs { get; protected set; }

        public GenericItem(string name, int sellIn, int quality, int basePrice, string attributs) : base(name, sellIn, quality, basePrice)
        {
            this.attributs = attributs;
        }

        public override void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }

        private void UpdateSellIn()
        {
            this.sellIn--;
        }

        private void UpdateQuality()
        {
            if (this.sellIn < 0)
            {
                this.quality--;
            }
            this.quality--;

            FloorQualityToZero();
            TopQualityToFifty();
        }
    }
}