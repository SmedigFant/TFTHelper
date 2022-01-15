using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes
{
    class TeamComposition
    {
        public List<Champion> TeamList { get; private set; }
        public Dictionary<Champion, List<Item>> BestItemOnCarries { get; private set; }
        public List<Item> ItemList { get; private set; }

        public TeamComposition(List<Champion> teamList, Dictionary<Champion, List<Item>> bestItems, List<Item> itemList)
        {
            this.TeamList = teamList;
            this.BestItemOnCarries = bestItems;
            this.ItemList = itemList;
        }

        public string TeamListToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Champion champ in TeamList)
            {
                sb.Append(champ.Name + " ");
            }
            return sb.ToString();
        }

       

       

        

        

    }
}
