using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes.Components
{
    class Tear : Item
    {
        enum TearItemEnumerator
        {
            SpearOfShojin = 10,
            FrozenHeart = 11,
            Redemption = 12,
            ArchangelStaff = 13,
            ChaliceOfPower = 14,
            StatikkShiv = 15,
            HandOfJustice = 16,
            AcademyEmblem = 17,
            BlueBuff = 18
        }
        public Tear()
        {
            this.SetName("Tear");
            this.SetValue(9);
        }
        public override Item Combine(Item item)
        {
            int fullItemValue = this.GetValue() + item.GetValue();
            TearItemEnumerator fullItem = (TearItemEnumerator)fullItemValue;
            return new FullItem(fullItem.ToString(), this.GetValue(), item.GetValue());
        }
    }
}
