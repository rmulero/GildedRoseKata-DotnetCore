using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }
                else if (Items[i].Name == "Aged Brie")
                {
                    increaseQuality(Items[i]);

                    decreaseSellIn(Items[i]);

                    if (Items[i].SellIn < 0)
                    {
                        increaseQuality(Items[i]);
                    }
                }
                else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    increaseQuality(Items[i]);

                    if (Items[i].SellIn < 11)
                    {
                        increaseQuality(Items[i]);
                    }
                    
                    if (Items[i].SellIn < 6)
                    {
                        increaseQuality(Items[i]);
                    }

                    decreaseSellIn(Items[i]);

                    if (Items[i].SellIn < 0)
                    {
                        setLowestQuality(Items[i]);
                    }
                }
                else
                {
                    decreaseQuality(Items[i]);

                    decreaseSellIn(Items[i]);

                    if (Items[i].SellIn < 0)
                    {
                        decreaseQuality(Items[i]);
                    }
                }
            }
        }

        private void increaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private void decreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private void setLowestQuality(Item item)
        {
            item.Quality = item.Quality - item.Quality;
        }

        private void decreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}
