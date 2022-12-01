namespace GildedRose.Items{
    public class LegendaryItem : Item
    {
        public string attributs { get; protected set; }

        public LegendaryItem(string name, int sellIn, int quality, int basePrice, string attributs) : base(name, sellIn, quality, basePrice)
        {
            this.attributs = attributs;
        }

        public override void Update()
        {
        }
    }
}