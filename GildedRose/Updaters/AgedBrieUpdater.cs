namespace GildedRoseKata
{
    public class AgedBrieUpdater : IUpdatableItem
    {
        private readonly Item item;

        public AgedBrieUpdater(Item item)
        {
            this.item = item;
        }

        public void UpdateItem()
        {
            // Determine how much to increase quality:
            // If sell-in has passed (sellin <= 0), increase by 2; otherwise, increase by 1.
            // Quality is capped at 50.
            int increment = item.SellIn <= 0 ? 2 : 1;
            item.Quality = System.Math.Min(50, item.Quality + increment);

            // Decrease sell-in value.
            item.SellIn--;
        }
    }
}