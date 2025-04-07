namespace GildedRoseKata
{
    public static class UpdaterFactory
    {
        public static IUpdatableItem Create(Item item)
        {
            return item.Name switch
            {
                ItemNames.AgedBrie => new AgedBrieUpdater(item),
                ItemNames.BackstagePass => new BackstagePassUpdater(item),
                ItemNames.Sulfuras => new SulfurasUpdater(item),
                ItemNames.ConjuredManaCake => new ConjuredItemUpdater(item),
                _ => new NormalItemUpdater(item),
            };
        }
    }
}