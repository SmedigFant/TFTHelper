using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTCompFinder.Classes.Components;

namespace TFTCompFinder.Classes
{
    static class ImportComps
    {
        public static List<TeamComposition> ImportWithDocument(HtmlDocument doc)
        {
            //The name of the class containing the correct elements may be renamed every couple of days
            var compList = doc.DocumentNode.Descendants()
                .Where(x => x.HasClass("m-1lptba")).ToList();


            List<TeamComposition> teamComps = new List<TeamComposition>();
            foreach (var comp in compList)
            {
                List<Champion> team = new List<Champion>();
                Dictionary<Champion, List<Item>> bestItems = new Dictionary<Champion, List<Item>>();
                List<Item> itemList = new List<Item>();


                HtmlNode compNameClass = comp.PreviousSibling;
                string compName = compNameClass.InnerText;
                
                

                HtmlNode child = comp.FirstChild;


                bool hasItems = true;
                while (child != null)
                {
                    Champion newChamp = new Champion(child.InnerText);
                    team.Add(newChamp);
                    if (hasItems)
                    {
                        try
                        {
                            string xPath = child.XPath + "/div/div[2]/img";
                            var allItemsClass = comp.SelectSingleNode(xPath);

                            List<Item> itemsForChamp = new List<Item>();
                            while (allItemsClass != null)
                            {
                                string singleItem = allItemsClass.GetAttributeValue("alt", "");
                                string[] singleItemArray = singleItem.Split('-');
                                StringBuilder sb = new StringBuilder();
                                foreach (string word in singleItemArray)
                                {
                                    sb.Append(Char.ToUpper(word[0]) + word.Substring(1));
                                }
                                Item newItem = new FullItem(sb.ToString());
                                itemsForChamp.Add(newItem);
                                itemList.Add(newItem);
                                allItemsClass = allItemsClass.NextSibling;
                            }
                            bestItems.Add(newChamp, itemsForChamp);
                        }
                        catch (NullReferenceException)
                        {
                            hasItems = false;
                            child = child.NextSibling;
                            continue;
                        }
                    }
                    child = child.NextSibling;
                }            
                teamComps.Add(TeamCompMaker.MakeComp(team, bestItems, itemList));
            }
            return teamComps;
        }

        
    }
}
