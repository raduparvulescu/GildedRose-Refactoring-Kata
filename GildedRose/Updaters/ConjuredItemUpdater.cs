namespace GildedRoseKata
{
    public class ConjuredItemUpdater : IUpdatableItem
    {
        private readonly Item item;

        public ConjuredItemUpdater(Item item)
        {
            this.item = item;
        }

        public void UpdateItem()
        {
            // Base degradation for normal items is 1 before the sell date,
            // so for conjured items, it should be 2.
            int degradation = 2;
            // If the sell date has passed, normal items degrade by 2,
            // so conjured items degrade by 4.
            if (item.SellIn <= 0)
            {
                degradation = 4;
            }
            // Ensure quality doesn't drop below 0.
            item.Quality = System.Math.Max(0, item.Quality - degradation);
            // Decrease sell date.
            item.SellIn--;
        }
    }
}