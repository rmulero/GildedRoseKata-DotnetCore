namespace csharpcore
{
    public class StandardItem : UpdatableItem
    {
        public StandardItem(string ItemName, int ItemSellIn, int ItemQuality) :
            base(ItemName, ItemSellIn, ItemQuality){}

        override public void Update()
        {
            DecreaseQuality();

            DecreaseSellIn();

            if (SellIn() < SELL_IN_EXPIRATION)
            {
                DecreaseQuality();
            }
        }
    }
}