using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private static string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private static string AGED_BRIE = "Aged Brie";
        private static string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";

        private static int SELL_IN_EXPIRATION = 0;

        private static int BACKSTAGE_INCREASE_QUALITY_BY_TWO_SELL_IN_THRESHOLD = 10;
        private static int BACKSTAGE_INCREASE_QUALITY_BY_THREE_SELL_IN_THRESHOLD = 5;

        private static int MAX_QUALITY = 50;
        private static int MIN_QUALITY = 0;

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name == SULFURAS)
                {
                    continue;
                }
                else if (item.Name == AGED_BRIE)
                {
                    increaseQuality(item);

                    decreaseSellIn(item);

                    if (item.SellIn < SELL_IN_EXPIRATION)
                    {
                        increaseQuality(item);
                    }
                }
                else if (item.Name == BACKSTAGE_PASSES)
                {
                    increaseQuality(item);

                    if (item.SellIn <= BACKSTAGE_INCREASE_QUALITY_BY_TWO_SELL_IN_THRESHOLD)
                    {
                        increaseQuality(item);
                    }
                    
                    if (item.SellIn <= BACKSTAGE_INCREASE_QUALITY_BY_THREE_SELL_IN_THRESHOLD)
                    {
                        increaseQuality(item);
                    }

                    decreaseSellIn(item);

                    if (item.SellIn < SELL_IN_EXPIRATION)
                    {
                        setLowestQuality(item);
                    }
                }
                else
                {
                    decreaseQuality(item);

                    decreaseSellIn(item);

                    if (item.SellIn < SELL_IN_EXPIRATION)
                    {
                        decreaseQuality(item);
                    }
                }
            }
        }

        private void increaseQuality(Item item)
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private void decreaseQuality(Item item)
        {
            if (item.Quality > MIN_QUALITY)
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
