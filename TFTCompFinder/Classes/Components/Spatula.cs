using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes.Components
{
    class Spatula : Item
    {
        enum SpatulaItemEnumerator
        {
            ImperialEmblem = 9,
            SyndicateEmblem = 10,
            ChemtechEmblem = 11,
            ArcanistEmblem = 12,
            MutantEmblem = 13,
            ChallengerEmblem = 14,
            AssassinEmblem =  15,
            TacticiansCrown = 16,
            AcademyEmblem = 17
        }

        public Spatula()
        {
            this.SetName("Spatula");
            this.SetValue(8);
        }

        public override Item Combine(Item item)
        {
            int fullItemValue = this.GetValue() + item.GetValue();
            SpatulaItemEnumerator fullItem = (SpatulaItemEnumerator)fullItemValue;
            return new FullItem(fullItem.ToString(), this.GetValue(), item.GetValue());
        }
    }
}
