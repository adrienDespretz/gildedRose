namespace GildedRose.Items{
    public class AgingItem : Item
    {
        public AgingItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
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
            // qualité tombe à 0 après sellIn <= 0 ????????
            this.quality++;

            FloorQualityToZero();
            TopQualityToFifty();
        }
    }
}