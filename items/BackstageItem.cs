namespace csharpcore
{
    public class BackstageItem : UpdatableItem
    {
        private static int BACKSTAGE_INCREASE_QUALITY_BY_TWO_SELL_IN_THRESHOLD = 10;
        private static int BACKSTAGE_INCREASE_QUALITY_BY_THREE_SELL_IN_THRESHOLD = 5;

        public BackstageItem(string ItemName, int ItemSellIn, int ItemQuality) :
            base(ItemName, ItemSellIn, ItemQuality){}

        override public void Update()
        {
            IncreaseQuality();

            if (SellIn() <= BACKSTAGE_INCREASE_QUALITY_BY_TWO_SELL_IN_THRESHOLD)
            {
                IncreaseQuality();
            }
            
            if (SellIn() <= BACKSTAGE_INCREASE_QUALITY_BY_THREE_SELL_IN_THRESHOLD)
            {
                IncreaseQuality();
            }

            DecreaseSellIn();

            if (SellIn() < SELL_IN_EXPIRATION)
            {
                SetLowestQuality();
            }
        }
    }
}