using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes.Components
{
    class SparringGloves : Item
    {
        enum GloveItemEnumerator
        {
            InfinityEdge = 8,
            ShroudOfStillness = 9,
            BansheesClaw = 10,
            JeweledGauntlet = 11,
            Quicksilver = 12,
            LastWhisper = 13,
            ThiefsGlove =  14,
            AssassinEmblem = 15,
            HandOfJustice = 16
        }

        public SparringGloves()
        {
            this.SetName("SparringGloves");
            this.SetValue(7);
        }

        public override Item Combine(Item item)
        {
            int fullItemValue = this.GetValue() + item.GetValue();
            GloveItemEnumerator fullItem = (GloveItemEnumerator)fullItemValue;
            return new FullItem(fullItem.ToString(), this.GetValue(), item.GetValue());
        }
    }
}
