using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<UpdatableItem> Items;
        public GildedRose(IList<UpdatableItem> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (UpdatableItem item in Items)
            {
                item.Update();
            }
        }
    }
}
