using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes.Components
{
    class RecurveBow : Item
    {
        enum RecurveItemEnumerator
        {
            GiantSlayer = 7,
            TitansResolve = 8,
            ZzRoth = 9,
            GuinsoosRageblade = 10,
            RunaansHurricane = 11,
            RapidFirecannon = 12,
            LastWhisper = 13,
            ChallengerEmblem = 14,
            StatikkShiv = 15
        }

        public RecurveBow()
        {
            this.SetName("RecurveBow");
            this.SetValue(6);
        }

        public override Item Combine(Item item)
        {
            int fullItemValue = this.GetValue() + item.GetValue();
            RecurveItemEnumerator fullItem = (RecurveItemEnumerator)fullItemValue;
            return new FullItem(fullItem.ToString(), this.GetValue(), item.GetValue());
        }
    }
}
