namespace GildedRose.Items
{
    public class ConjuredItem : Item
    {

        public ConjuredItem(string name, int sellIn, int quality, int basePrice) : base(name, sellIn, quality, basePrice)
        {

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
                this.quality -= 2;
            }
            this.quality -= 2;

            FloorQualityToZero();
            TopQualityToFifty();
        }
    }
}