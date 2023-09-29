using System;
using GildedRoseKata;
using System.Collections.Generic;

namespace csharp;
    public class GildedRose
    {
        readonly IList<Item> Items;
        private const int MAXIMUM_QUALITY = 50;
        private const int MINIMUM_QUALITY = 0;
        private readonly Dictionary<string, Action<Item>> _itemUpdateMethods = new()
        {
            { "Aged Brie", DoForAgedBrie },
            { "Backstage passes to a TAFKAL80ETC concert", DoForBackStagePass },
            { "Sulfuras, Hand of Ragnaros", DoForSulfuras },
            { "Conjured Mana Cake", DoForConjure },
            // Add more items as needed
        };
        private void UpdateItem(Item item)
        {
                _itemUpdateMethods.TryGetValue(item.Name, out var updateMethod);
                (updateMethod ?? DoForRegularItem)(item);
        }
        public GildedRose(IList<Item> Items) => this.Items = Items;

        public void UpdateQuality()
        {
            foreach (var item in Items) UpdateItem(item);
        }
        private static void DoForSulfuras(Item item){}
        private static void UpdateItemCommon(Item item, int qualityChange)
        {
            item.SellIn--;
            item.Quality += qualityChange;
            if (item.SellIn < 0)
                item.Quality += qualityChange;
            item.Quality = Math.Max(MINIMUM_QUALITY, Math.Min(item.Quality, MAXIMUM_QUALITY));
        }
        private static void DoForBackStagePass(Item item)
        {
        int qualityChange = (item.SellIn > 10) ? 1 :
            (item.SellIn <= 5) ? 3 :
            (item.SellIn <= 10) ? 2 : 0;
        UpdateItemCommon(item, qualityChange);
        if (item.SellIn < 0) item.Quality = 0;
    }
        private static void DoForAgedBrie(Item item) => UpdateItemCommon(item, 1);
        private static void DoForConjure(Item item) => UpdateItemCommon(item, -2);
        private static void DoForRegularItem(Item item) => UpdateItemCommon(item, -1);
    }
