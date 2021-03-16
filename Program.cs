using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<UpdatableItem> Items = new List<UpdatableItem>{
                UpdatableItemFactory.CreateItem(ItemType.STANDARD, "+5 Dexterity Vest", 10, 20),
                UpdatableItemFactory.CreateItem(ItemType.AGED, "Aged Brie", 2, 0),
                UpdatableItemFactory.CreateItem(ItemType.STANDARD, "Elixir of the Mongoose", 5, 7),
                UpdatableItemFactory.CreateItem(ItemType.LEGENDARY, "Sulfuras, Hand of Ragnaros", 0, 80),
                UpdatableItemFactory.CreateItem(ItemType.LEGENDARY, "Sulfuras, Hand of Ragnaros", -1, 80),
                UpdatableItemFactory.CreateItem(ItemType.BACKSTAGE, "Backstage passes to a TAFKAL80ETC concert", 15, 20),
                UpdatableItemFactory.CreateItem(ItemType.BACKSTAGE, "Backstage passes to a TAFKAL80ETC concert", 10, 49),
                UpdatableItemFactory.CreateItem(ItemType.BACKSTAGE, "Backstage passes to a TAFKAL80ETC concert", 5, 49),
				UpdatableItemFactory.CreateItem(ItemType.CONJURED, "Conjured Mana Cake", 3, 6)
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (UpdatableItem item in Items)
                {
                    System.Console.WriteLine(item);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
