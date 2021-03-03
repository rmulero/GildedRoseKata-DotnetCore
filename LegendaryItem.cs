namespace csharpcore
{
    public class LegendaryItem : UpdatableItem
    {
        public LegendaryItem(string ItemName, int ItemSellIn, int ItemQuality) :
            base(ItemName, ItemSellIn, ItemQuality){}

        override public void Update(){}
    }
}