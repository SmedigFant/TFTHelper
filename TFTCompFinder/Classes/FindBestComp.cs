using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes
{
    static class FindBestComp
    {
        public static ScoreAndItemList FindScore(List<List<Item>> itemsAvailable, TeamComposition teamComp)
        {
            int score = 0;
            List<List<Item>> preferredItemList = new List<List<Item>>();

            //if (itemsAvailable.Count % 2 != 0)
            //{
            //    itemsAvailable.RemoveAt(itemsAvailable.Count-1);
            //}

            foreach (List<Item> items in itemsAvailable)
            {
                int thisScore = 0;
                List<Item> itemsLeft = new List<Item>(items);
                List<Item> itemsLeftRequired = new List<Item>(teamComp.ItemList);
                if (itemsLeft.Count != 0)
                {
                    foreach (Item item in items)
                    {
                        if (itemsLeftRequired.Any(x => x.GetName() == item.GetName()))
                        {
                            itemsLeftRequired.Remove(itemsLeftRequired.Find(x => x.GetName() == item.GetName()));
                            itemsLeft.Remove(item);
                            thisScore++;
                        }
                    }

                    if (thisScore > score)
                    {
                        score = thisScore;
                        preferredItemList.Clear();
                        preferredItemList.Add(items);
                    }
                    else if (thisScore == score)
                    {
                        preferredItemList.Add(items);
                    }
                }
            }
            return new ScoreAndItemList(preferredItemList, score);
        }
    }
}
