namespace GildedRose.Items
{
    public class GenericItem : Item
    {

        public GenericItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
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
                this.quality--;
            }
            this.quality--;

            FloorQualityToZero();
            TopQualityToFifty();
        }
    }
}