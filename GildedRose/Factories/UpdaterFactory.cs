namespace GildedRoseKata
{
    public static class UpdaterFactory
    {
        public static IUpdatableItem Create(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => new AgedBrieUpdater(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassUpdater(item),
                "Sulfuras, Hand of Ragnaros" => new SulfurasUpdater(item),
                "Conjured Mana Cake" => new ConjuredItemUpdater(item),
                _ => new NormalItemUpdater(item),
            };
        }
    }
}