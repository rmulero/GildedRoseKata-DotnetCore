using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {

        [Fact]
        public void SellInDegradesByOneAfterOneDay()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "foo", SellIn = 1, Quality = 10 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].SellIn);
        }

        [Fact]
        public void QualityDegradesByOneAfterOneDay()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "foo", SellIn = 1, Quality = 10 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].Quality);
        }

        [Fact]
        public void QualityDegradesTwiceAsFastWhenSellByDateHasPassed()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "foo", SellIn = 0, Quality = 10 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void QualityOfAnItemIsNeverNegative()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "foo", SellIn = 0, Quality = 0 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void AgedBrieIncreasesQualityTheOlderItGets()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void AgedBrieIncreasesQualityTwiceAsFastWhenSellByDateHasPassed()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void QualityOfAnItemIsNeverMoreThan50()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void SulfurasQualityAndSellInValuesAreNotAltered()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);
        }

        [Fact]
        public void BackstageIncreasesQualityByOneIfMoreThanTenDaysRemaining()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 0 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void BackstageIncreasesQualityByTwoIfItHasToBeSoldInTenDaysOrLess()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void BackstageIncreasesQualityByThreeIfItHasToBeSoldInFiveDaysOrLess()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void BackstageQualityDropsToZeroAfterTheConcert()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
    }
}