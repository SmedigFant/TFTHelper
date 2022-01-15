using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTCompFinder.Classes.Components;

namespace TFTCompFinder.Classes
{
    static class ItemFactory
    {
        public static List<Item> MakeItemsFromString(string itemString)
        {
            string[] arrayOfItems = itemString.Split(' ');
            List<Item> items = new List<Item>();

            foreach (string item in arrayOfItems)
            {
                items.Add(MakeItem(item));
            }
            return items;
        }

        public static Item MakeItem(string iString)
        {
            switch (iString)
            {
                case "sword":
                    return new BFSword();

                case "vest":
                    return new ChainVest();

                case "belt":
                    return new GiantsBelt();

                case "rod":
                    return new NeedlesslyLargeRod();

                case "cloak":
                    return new NegatronCloak();

                case "bow":
                    return new RecurveBow();

                case "gloves":
                    return new SparringGloves();

                case "spat":
                    return new Spatula();

                case "tear":
                    return new Tear();

                default:
                    return new FullItem(iString);
     
            }
        }
    }
}
