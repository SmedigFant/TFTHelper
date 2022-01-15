using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes.Components
{
    class ChainVest : Item
    {
        enum VestItemEnumerator
        {
            GuardianAngel = 3, //Guardian Angel
            BrambleVest = 4, //Bramble Vest
            SunfireCape = 5, //Sunfire Cape
            LocketOfTheIronSolari = 6, //Locket of the Iron Solari
            GargoyleStoneplate = 7, //Gargoyle Stoneplate
            TitansResolve = 8,  //Titans Resolve
            ShroudOfStillness = 9, //Shroud of Stillness
            SyndicateEmblem = 10, //Syndicate Emblem
            FrozenHeart = 11, //Frozen Heart
        }
        public ChainVest()
        {
            this.SetName("ChainVest");
            this.SetValue(2);
        }
        public override Item Combine(Item item)
        {
            int fullItemValue = this.GetValue() + item.GetValue();
            VestItemEnumerator fullItem = (VestItemEnumerator)fullItemValue;
            return new FullItem(fullItem.ToString(), this.GetValue(), item.GetValue());
        }
    }
}
