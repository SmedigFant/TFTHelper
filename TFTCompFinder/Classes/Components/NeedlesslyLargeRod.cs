using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes.Components
{
    class NeedlesslyLargeRod : Item
    {
        enum RodItemEnumerator
        {
            HextechGunblade = 5,
            LocketOfTheIronSolari = 6,
            Morellonomicon = 7,
            RabadonsDeathcap = 8,
            IonicSpark = 9,
            GuinsoosRageblade = 10,
            JeweledGauntlet = 11,
            ArcanistEmblem = 12,
            ArchangelStaff = 13
        }
        
       
        public NeedlesslyLargeRod()
        {
            this.SetName("NeedlesslyLargeRod");
            this.SetValue(4);
        }

        public override Item Combine(Item item)
        {
            int fullItemValue = this.GetValue() + item.GetValue();
            RodItemEnumerator fullItem = (RodItemEnumerator)fullItemValue;
            return new FullItem(fullItem.ToString(), this.GetValue(), item.GetValue());
        }

    }
}
