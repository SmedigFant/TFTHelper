using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes
{
    class ScoreAndItemList
    {
        public List<List<Item>> ItemList;
        public int Score;

        public ScoreAndItemList(List<List<Item>> itemList, int score)
        {
            this.ItemList = itemList;
            this.Score = score;
        }
    }
}
