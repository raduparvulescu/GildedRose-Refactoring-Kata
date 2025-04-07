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
            if (item.SellIn > 0)
            {
                // Base increase is 1.
                int increment = 1;
                // Increase additional if there are 10 days or less.
                if (item.SellIn <= 10)
                {
                    increment++;
                }
                // Increase even more if there are 5 days or less.
                if (item.SellIn <= 5)
                {
                    increment++;
                }
                item.Quality = System.Math.Min(50, item.Quality + increment);
            }
            else
            {
                // Once the concert is over, quality drops to 0.
                item.Quality = 0;
            }

            // Decrement the sell-in value.
            item.SellIn--;
        }
    }
}