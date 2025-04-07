namespace GildedRoseKata
{
    public class NormalItemUpdater : IUpdatableItem
    {
        private readonly Item item;

        public NormalItemUpdater(Item item)
        {
            this.item = item;
        }

        public void UpdateItem()
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
            item.SellIn--;
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}