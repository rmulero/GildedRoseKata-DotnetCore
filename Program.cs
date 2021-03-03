﻿using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<UpdatableItem> Items = new List<UpdatableItem>{
                new StandardItem("+5 Dexterity Vest", 10, 20),
                new AgedItem("Aged Brie", 2, 0),
                new StandardItem("Elixir of the Mongoose", 5, 7),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", -1, 80),
                new BackstageItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new BackstageItem("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                new BackstageItem("Backstage passes to a TAFKAL80ETC concert", 5, 49),
				// this conjured item does not work properly yet
				new StandardItem("Conjured Mana Cake", 3, 6)
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name() + ", " + Items[j].SellIn() + ", " + Items[j].Quality());
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
