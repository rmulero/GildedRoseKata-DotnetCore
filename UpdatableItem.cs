namespace csharpcore
{
    public abstract class UpdatableItem
    {
        protected static int SELL_IN_EXPIRATION = 0;
        private static int MAX_QUALITY = 50;
        private static int MIN_QUALITY = 0;

        private Item item;

        public UpdatableItem(string ItemName, int ItemSellIn, int ItemQuality)
        {
            item = new Item{ Name = ItemName, SellIn = ItemSellIn, Quality = ItemQuality };
        }

        public abstract void Update();

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

        public override string ToString()
        {
            return Name() + ", " + SellIn() + ", " + Quality();
        }

        protected void IncreaseQuality()
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality = item.Quality + 1;
            }
        }

        protected void DecreaseQuality()
        {
            if (item.Quality > MIN_QUALITY)
            {
                item.Quality = item.Quality - 1;
            }
        }

        protected void SetLowestQuality()
        {
            item.Quality = item.Quality - item.Quality;
        }

        protected void DecreaseSellIn()
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}