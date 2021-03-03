using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {

        [Fact]
        public void SellInDegradesByOneAfterOneDay()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.STANDARD, "foo", 1, 10 )
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].SellIn());
        }

        [Fact]
        public void QualityDegradesByOneAfterOneDay()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.STANDARD, "foo", 1, 10 )
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].Quality());
        }

        [Fact]
        public void QualityDegradesTwiceAsFastWhenSellByDateHasPassed()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.STANDARD, "foo", 0, 10 )
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(8, Items[0].Quality());
        }

        [Fact]
        public void QualityOfAnItemIsNeverNegative()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.STANDARD, "foo", 0, 0 )
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality());
        }

        [Fact]
        public void AgedBrieIncreasesQualityTheOlderItGets()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.AGED, "Aged Brie", 1, 0)
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality());
        }

        [Fact]
        public void AgedBrieIncreasesQualityTwiceAsFastWhenSellByDateHasPassed()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.AGED, "Aged Brie", 0, 0 )
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality());
        }

        [Fact]
        public void QualityOfAnItemIsNeverMoreThan50()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.AGED, "Aged Brie", 0, 50)
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality());
        }

        [Fact]
        public void SulfurasQualityAndSellInValuesAreNotAltered()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.LEGENDARY, "Sulfuras, Hand of Ragnaros", 0, 80)
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality());
            Assert.Equal(0, Items[0].SellIn());
        }

        [Fact]
        public void BackstageIncreasesQualityByOneIfMoreThanTenDaysRemaining()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.BACKSTAGE, "Backstage passes to a TAFKAL80ETC concert", 11, 0)
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality());
        }

        [Fact]
        public void BackstageIncreasesQualityByTwoIfItHasToBeSoldInTenDaysOrLess()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.BACKSTAGE, "Backstage passes to a TAFKAL80ETC concert", 10, 0)
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality());
        }

        [Fact]
        public void BackstageIncreasesQualityByThreeIfItHasToBeSoldInFiveDaysOrLess()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.BACKSTAGE, "Backstage passes to a TAFKAL80ETC concert", 5, 0)
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(3, Items[0].Quality());
        }

        [Fact]
        public void BackstageQualityDropsToZeroAfterTheConcert()
        {
            IList<UpdatableItem> Items = new List<UpdatableItem> {
                UpdatableItemFactory.CreateItem(ItemType.BACKSTAGE, "Backstage passes to a TAFKAL80ETC concert", 0, 50)
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality());
        }
    }
}