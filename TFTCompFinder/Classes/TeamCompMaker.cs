using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes
{
    class TeamCompMaker
    {
        public static TeamComposition MakeComp(List<Champion> team, Dictionary<Champion, List<Item>> itemAndCarriers, List<Item> itemList)
        {
            return new TeamComposition(team, itemAndCarriers, itemList);
        }
    }
}
