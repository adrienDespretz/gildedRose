using GildedRose.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Domain
{
    public class RelicItem : Item
    {
        public RelicItem(string name, int sellIn, int quality, int basePrice) : base(name, sellIn, quality, basePrice)
        {
        }

        public override void Update()
        {
            this.basePrice += 100;
        }
    }
}
