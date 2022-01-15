using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes.Components
{
    class BFSword : Item
    {
        enum SwordItemEnumerator
        {
            DeathBlade = 2,
            GuardianAngel = 3,
            ZekesHerald = 4, //Zekes Herald
            HextechGunblade = 5, //Hextech Gunblade
            Bloodthirster = 6, //Bloodthirster
            Giantslayer = 7, //Giantslayer
            InfinityEdge = 8, //Infinity Edge
            ImperialEmblem = 9, //Imperial Emblem
            SpearOfShojin = 10, //Spear of Shojin
        }

        public BFSword()
        {
            this.SetName("B.F.Sword");
            this.SetValue(1);
        }

        public override Item Combine(Item item)
        {
            int fullItemValue = this.GetValue() + item.GetValue();
            SwordItemEnumerator fullItem = (SwordItemEnumerator)fullItemValue;
            return new FullItem(fullItem.ToString(), this.GetValue(), item.GetValue());
        }
    }
}
