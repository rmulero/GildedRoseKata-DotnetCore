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

        IList<UpdatableItem> Items;
        public GildedRose(IList<UpdatableItem> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (UpdatableItem item in Items)
            {
                if (item.Name() == SULFURAS)
                {
                    continue;
                }
                else if (item.Name() == AGED_BRIE)
                {
                    item.IncreaseQuality();

                    item.DecreaseSellIn();

                    if (item.SellIn() < SELL_IN_EXPIRATION)
                    {
                        item.IncreaseQuality();
                    }
                }
                else if (item.Name() == BACKSTAGE_PASSES)
                {
                    item.IncreaseQuality();

                    if (item.SellIn() <= BACKSTAGE_INCREASE_QUALITY_BY_TWO_SELL_IN_THRESHOLD)
                    {
                        item.IncreaseQuality();
                    }
                    
                    if (item.SellIn() <= BACKSTAGE_INCREASE_QUALITY_BY_THREE_SELL_IN_THRESHOLD)
                    {
                        item.IncreaseQuality();
                    }

                    item.DecreaseSellIn();

                    if (item.SellIn() < SELL_IN_EXPIRATION)
                    {
                        item.SetLowestQuality();
                    }
                }
                else
                {
                    item.DecreaseQuality();

                    item.DecreaseSellIn();

                    if (item.SellIn() < SELL_IN_EXPIRATION)
                    {
                        item.DecreaseQuality();
                    }
                }
            }
        }
    }
}
