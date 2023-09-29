using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using csharp;
using ExtensionMethod;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> items = new List<Item>{

                "+5 Dexterity Vest".Items(10,20),
                "Aged Brie".Items(2,0),
                "Elixir of the Mongoose".Items(5,7),
                "Sulfuras, Hand of Ragnaros".Items(0,80),
                "Sulfuras, Hand of Ragnaros".Items(-1,80),
                "Backstage passes to a TAFKAL80ETC concert".Items(15,20),
                "Backstage passes to a TAFKAL80ETC concert".Items(10,49),
                "Backstage passes to a TAFKAL80ETC concert".Items(5,49),
                "Conjured Mana Cake".Items(5,40)
            };

            GildedRose app = new GildedRose(items);
            for (int i = 0; i < 30; i++)
                app.UpdateQuality();



            Assert.Equal(-20, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);



            Assert.Equal(-28, items[1].SellIn);
            Assert.Equal(50, items[1].Quality);



            Assert.Equal(-25, items[2].SellIn);
            Assert.Equal(0, items[2].Quality);



            Assert.Equal(0, items[3].SellIn);
            Assert.Equal(80, items[3].Quality);



            Assert.Equal(-1, items[4].SellIn);
            Assert.Equal(80, items[4].Quality);



            Assert.Equal(-15, items[5].SellIn);
            Assert.Equal(0, items[5].Quality);



            Assert.Equal(-20, items[6].SellIn);
            Assert.Equal(0, items[6].Quality);



            Assert.Equal(-25, items[7].SellIn);
            Assert.Equal(0, items[7].Quality);



            Assert.Equal(-25, items[8].SellIn);
            Assert.Equal(0, items[8].Quality);
        }
    }
}