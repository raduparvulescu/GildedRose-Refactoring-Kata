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
            if (item.Quality < 50)
            {
                item.Quality++;
            }
            item.SellIn--;
            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }
}