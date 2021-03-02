namespace csharpcore
{
    public class UpdatableItem
    {
        private static int MAX_QUALITY = 50;
        private static int MIN_QUALITY = 0;

        private Item item;

        public UpdatableItem(string ItemName, int ItemSellIn, int ItemQuality)
        {
            item = new Item{ Name = ItemName, SellIn = ItemSellIn, Quality = ItemQuality };
        }

        public string Name()
        {
            return item.Name;
        }

        public int Quality()
        {
            return item.Quality;
        }

        public int SellIn()
        {
            return item.SellIn;
        }

        public void IncreaseQuality()
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality = item.Quality + 1;
            }
        }

        public void DecreaseQuality()
        {
            if (item.Quality > MIN_QUALITY)
            {
                item.Quality = item.Quality - 1;
            }
        }

        public void SetLowestQuality()
        {
            item.Quality = item.Quality - item.Quality;
        }

        public void DecreaseSellIn()
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}