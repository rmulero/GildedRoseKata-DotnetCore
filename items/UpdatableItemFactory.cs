namespace csharpcore
{
    public class UpdatableItemFactory
    {
        public static UpdatableItem CreateItem(ItemType Type, string Name, int SellIn, int Quality)
        {
            switch (Type)
            {
                case ItemType.AGED:
                    return new AgedItem(Name, SellIn, Quality);
                case ItemType.BACKSTAGE:
                    return new BackstageItem(Name, SellIn, Quality);
                case ItemType.LEGENDARY:
                    return new LegendaryItem(Name, SellIn, Quality);
                case ItemType.STANDARD:
                default:
                    return new StandardItem(Name, SellIn, Quality);
            }
        }
    }
}