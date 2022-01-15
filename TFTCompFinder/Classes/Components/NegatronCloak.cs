using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes.Components
{
    class NegatronCloak : Item
    {
        enum CloakItemEnumerator
        {
            Bloodthirster = 6,
            GargoyleStoneplate = 7,
            Zephyr = 8,
            IonicSpark = 9,
            DragonsClaw = 10,
            RunaansHurricane = 11,
            Quicksilver = 12,
            MutantEmblem = 13,
            ChaliceOfPower = 14
        }
        public NegatronCloak()
        {
            this.SetName("NegatronCloak");
            this.SetValue(5);
        }

        public override Item Combine(Item item)
        {
            int fullItemValue = this.GetValue() + item.GetValue();
            CloakItemEnumerator fullItem = (CloakItemEnumerator)fullItemValue;
            return new FullItem(fullItem.ToString(), this.GetValue(), item.GetValue());
        }
    }
}
