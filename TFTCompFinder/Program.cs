using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TFTCompFinder.Classes;
using TFTCompFinder.Classes.Components;

namespace TFTCompFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Legger fysisk inn en liste med navn på items som skal inn i funksjonen
            //Først må disse lages

            string iString = "bow cloak gloves sword";

            //Starting the task of retrieving the html document to be used later, this usually takes about ~0.8s
            Task<HtmlDocument> htmlDocument = GetHtmlAsync();

            //Finner perms med string --> fant at å bruke en liste med objekter var mye raskere siden jeg slipper å bruke StringBuilder
            //List<string[]> stringPermutations = PermutationFinderv2.FindPermutations(iString);

            //Console.WriteLine(stringPermutations.Count);


            List<Item> itemList = ItemFactory.MakeItemsFromString(iString);

            List<Item> allPossibleItems = PermutationFinder.FindAllFullItems(itemList);
            Dictionary<int, Item> possibleItemDict = new Dictionary<int, Item>();
            foreach (Item item in allPossibleItems)
            {
                possibleItemDict.Add(item.GetValue(), item);
            }
            
            List<List<Item>> itemPermutations = PermutationFinder.FindPermutations(itemList.ToArray());
            
            
            List<List<Item>> distinctPermsList1 = PermutationFinder.FindAllDistinctPermutations(possibleItemDict, itemPermutations);

            //HashSet<string> distinctPerms = new HashSet<string>();
            //HashSet<List<Item>> distinctPermsObjects = new HashSet<List<Item>>();
            //PermutationFinderv3.FindAllDistinctPermutations(itemPermutations, distinctPerms, distinctPermsObjects);

            //List<List<Item>> distinctPermsList = new List<List<Item>>();

            //foreach (string perm in distinctPerms)
            //{
            //    distinctPermsList.Add(ItemFactory.MakeItemsFromString(perm));
            //}


            HtmlDocument doccyMent = htmlDocument.Result;
            List<TeamComposition> teamCompositions = ImportComps.ImportWithDocument(doccyMent);

            Dictionary<TeamComposition, int> teamCompScores = new Dictionary<TeamComposition, int>();
            
            Dictionary<TeamComposition, List<List<Item>>> teamCompBestLists = new Dictionary<TeamComposition, List<List<Item>>>();
            foreach (var comp in teamCompositions)
            {
                ScoreAndItemList forThisComp = FindBestComp.FindScore(distinctPermsList1, comp);
                teamCompScores.Add(comp, forThisComp.Score);
                teamCompBestLists.Add(comp, forThisComp.ItemList);
            }
            Console.WriteLine(teamCompScores.Values.Max());
            Console.WriteLine("Comp with best compatability with current items: ");
            TeamComposition keyOfMaxValue = teamCompScores.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            Console.WriteLine(keyOfMaxValue.TeamListToString());

            foreach (var list in teamCompBestLists[keyOfMaxValue])
            {
                foreach (var item in list)
                {
                    Console.Write(item.ToString() + " ");
                }
                Console.WriteLine("");
            }
            


            //Send inn items du har og finn beste comp...
            //FindBestComp(itemList); 
        }

        private static async Task<HtmlDocument> GetHtmlAsync()
        {
            //var url = "https://tftactics.gg/tierlist/team-comps";

            HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlDocument doc = await Task.Run(() => web.Load("https://app.mobalytics.gg/tft/team-comps"));

            return doc;
        }

    
    }
}
