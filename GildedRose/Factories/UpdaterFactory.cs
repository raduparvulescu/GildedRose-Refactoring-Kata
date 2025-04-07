namespace GildedRoseKata
{
    // so, I went for polymorphism here because I didn’t want to mess with the goblin’s
    // sacred Item class; instead, I wrapped each item’s update logic in its own
    // updater class (all sharing a common interface) so I can easily swap in the right
    // behavior for each item type - this way, we can add new items or tweak things
    // without ever touching the goblin’s code
    // I think it’s a neat, scalable hack that keeps the code clean and, more importantly,
    // keeps the goblin happy
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