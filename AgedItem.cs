namespace csharpcore
{
    public class AgedItem : UpdatableItem
    {
        public AgedItem(string ItemName, int ItemSellIn, int ItemQuality) :
            base(ItemName, ItemSellIn, ItemQuality){}

        override public void Update()
        {
            IncreaseQuality();

            DecreaseSellIn();

            if (SellIn() < SELL_IN_EXPIRATION)
            {
                IncreaseQuality();
            }
        }
    }
}