using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes
{
    class PermutationFinder
    {
        static bool ShouldSwap(Item[] str, int start, int curr)
        {
            for (int i = start; i < curr; i++)
            {

                string name = str[i].GetName();
                string name2 = str[curr].GetName();
                if (str[i].GetName() == str[curr].GetName())
                {
                   
                    return false;
                }
            }
            return true;
        }

        // Prints all distinct permutations
        // in str[0..n-1]
        static void FindPermutations(Item[] str, int index, int n, ref List<List<Item>> itemList)
        {
            if (index >= n)
            {
                List<Item> newItemPerm = str.ToList();
                itemList.Add(newItemPerm);
                return;
            }

            for (int i = index; i < n; i++)
            {


                // Proceed further for str[i] only
                // if it doesn't match with any of
                // the characters after str[index]
                bool check = ShouldSwap(str, index, i);

                if (check)
                {
                    str = Swap(str, index, i);
                    FindPermutations(str, index + 1, n, ref itemList);
                    str = Swap(str, index, i);
                }
            }
        }

        static Item[] Swap(Item[] str, int i, int j)
        {
            Item temp = str[i];
            Item temp2 = str[j];
 
            str[i] = temp2;
            str[j] = temp;
            
            return str;
        }

        // Driver code
        public static List<List<Item>> FindPermutations(Item[] itemArray)
        {
            List<List<Item>> itemList = new List<List<Item>>();
            int n = itemArray.Length;
            FindPermutations(itemArray, 0, n, ref itemList);
            return itemList;
        }


        public static void FindAllDistinctPermutations(List<List<Item>> allPerms, HashSet<string> distinctPerms, HashSet<List<Item>> distinctPermsObjects)
        {
            foreach (var permutation in allPerms)
            {
                
                StringBuilder thisPerm = new StringBuilder();
                List<Item> sortingListFullItem = new List<Item>();
                List<string> sortingList = new List<string>();


                string lastItem = "";
                bool hasLastComponent = false;
                for (int i = 0; i < permutation.Count; i += 2)
                {
                    if (i + 1 == permutation.Count)
                    {
                        //sortingListFullItem.Add(permutation[i]);
                        //lastItem = permutation[i].GetName();
                        //hasLastComponent = true;
                    }
                    else
                    {
                        sortingListFullItem.Add(permutation[i].Combine(permutation[i + 1]));
                        sortingList.Add(permutation[i].Combine(permutation[i + 1]).ToString());
                    }
                }

                List<Item> sortedListFullItems = sortingListFullItem.OrderBy(x => x.ToString()).ToList();

                var sortedList = sortingList.OrderBy(x => x.ToString());

                foreach (var item in sortedList)
                {
                    thisPerm.Append(item + " ");
                }
                if (hasLastComponent)
                {
                    thisPerm.Append(lastItem);
                }

                distinctPerms.Add(thisPerm.ToString().TrimEnd());
               
                
             
            }

        }

        public static List<List<Item>> FindAllDistinctPermutations(Dictionary<int, Item> possibleItemsDict, List<List<Item>> allPerms)
        {
            List<List<Item>> distinctPermsList = new List<List<Item>>();
            HashSet<double> distinctPermValue = new HashSet<double>();
            foreach (var permutation in allPerms)
            {
                List<Item> listToSort = new List<Item>();
                List<int> intValueOfItems = new List<int>();
                for (int i = 0; i < permutation.Count; i += 2)
                {
                    if (i + 1 == permutation.Count)
                    {
                        //listToSort.Add(permutation[i]);
                    }
                    else
                    {
                        Item fullItem = permutation[i].Combine(permutation[i + 1]);
                        intValueOfItems.Add(fullItem.GetValue());
                        listToSort.Add(possibleItemsDict[fullItem.GetValue()]);
                    }
                }
                
                intValueOfItems.Sort();
                double totalValueOfItemSet = MakeValueWithAccumulator(intValueOfItems);
                if (distinctPermValue.Add(totalValueOfItemSet))
                {
                    distinctPermsList.Add(listToSort);
                }
            }
            return distinctPermsList;
        }

        public static List<Item> FindAllFullItems(List<Item> itemList)
        {
            List<Item> allItemsList = new List<Item>();
            HashSet<string> allFullStrings = new HashSet<string>();
            for (int i = 0; i < itemList.Count; i++)
            {
                for (int j = i; j < itemList.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    Item FullItem = itemList[i].Combine(itemList[j]);
                    if (allFullStrings.Add(FullItem.GetName()))
                    {
                        allItemsList.Add(FullItem);
                    }
                }
            }
            return allItemsList;
            
        }

        private static double MakeValueWithAccumulator(List<int> singleItemValues)
        {
            double result = 0;
            foreach (double value in singleItemValues)
            {
                result *= 100;
                result += value;
            }
            return result;
        }
    }


    // This code is contributed
    // by 29AjayKumar

}

