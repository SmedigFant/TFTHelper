using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes
{
    class Champion
    {
        public string Name { get; private set; }
        public List<Item> ItemsHeld { get; private set; }

        public Champion(string name)
        {
            this.Name = name;
        }

        public bool GiveItem(Item item)
        {
            if (ItemsHeld.Count > 2)
            {
                return false;
            }
            else
            {
                ItemsHeld.Add(item);
                return true;
            }
        }
    }
}
