using System;
using System.Collections.Generic;
using csharp;
using ExtensionMethod;
using GildedRoseKata;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
               
                 "+5 Dexterity Vest".Items(10,20),
                "Aged Brie".Items(2,0),
                 "Elixir of the Mongoose".Items(5,7),
                 "Sulfuras, Hand of Ragnaros".Items(0,80),
               "Sulfuras, Hand of Ragnaros".Items(-1,80),
                "Backstage passes to a TAFKAL80ETC concert".Items(15,20),
                "Backstage passes to a TAFKAL80ETC concert".Items(10,49),
                "Backstage passes to a TAFKAL80ETC concert".Items(5,49),
				"Conjured Mana Cake".Items(5,40)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}

namespace ExtensionMethod
{
    public static class ExtensionClass
    {
        public static Item Items(this string name, int sellin, int quality) =>
            new Item { Name = name, SellIn = sellin, Quality = quality };
    }
}
