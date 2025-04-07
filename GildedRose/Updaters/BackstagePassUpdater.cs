namespace GildedRoseKata
{
    public class BackstagePassUpdater : IUpdatableItem
    {
        private readonly Item item;

        public BackstagePassUpdater(Item item)
        {
            this.item = item;
        }

        public void UpdateItem()
        {
            if (item.Quality < 50)
            {
                // Base increase
                item.Quality++;
                if (item.SellIn <= 10 && item.Quality < 50)
                {
                    // Additional increase when 10 days or less
                    item.Quality++;
                }
                if (item.SellIn <= 5 && item.Quality < 50)
                {
                    // Additional increase when 5 days or less
                    item.Quality++;
                }
            }
            item.SellIn--;
            if (item.SellIn < 0)
            {
                // Once the concert is over, quality drops to 0.
                item.Quality = 0;
            }
        }
    }
}