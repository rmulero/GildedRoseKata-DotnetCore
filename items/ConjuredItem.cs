namespace csharpcore
{
    public class ConjuredItem : UpdatableItem
    {
        public ConjuredItem(string ItemName, int ItemSellIn, int ItemQuality) :
            base(ItemName, ItemSellIn, ItemQuality){}

        override public void Update()
        {
            DecreaseQualityTwice();

            DecreaseSellIn();

            if (SellIn() < SELL_IN_EXPIRATION)
            {
                DecreaseQualityTwice();
            }
        }

        private void DecreaseQualityTwice() 
        {
            DecreaseQuality();
            DecreaseQuality();
        }
    }
}