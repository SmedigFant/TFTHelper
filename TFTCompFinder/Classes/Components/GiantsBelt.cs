using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes.Components
{
    class GiantsBelt : Item
    {
        enum BeltItemEnumerator
        {
            ZekesHerald = 4, //Zekes Herald
            SunfireCape = 5, //Sunfire Cape
            WarmogsArmor = 6, //Warmogs Armor
            Morellonomicon = 7, //Morellonomicon
            Zephyr = 8, // Zephyr
            ZzRoth = 9, // Zz'Roth
            BansheesClaw = 10, // Trap Claw
            ChemtechEmblem = 11, // Chemtech Emblem
            Redemption = 12, //Redemption
        }
        public GiantsBelt()
        {
            this.SetName("GiantsBelt");
            this.SetValue(3);
        }

        public override Item Combine(Item item)
        {
            int fullItemValue = this.GetValue() + item.GetValue();
            BeltItemEnumerator fullItem = (BeltItemEnumerator)fullItemValue;

            return new FullItem(fullItem.ToString(), this.GetValue(), item.GetValue());
        }
    }
}
