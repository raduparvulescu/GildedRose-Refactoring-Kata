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
            // If sellin is 0 or less, degrade quality by 2; otherwise, by 1.
            int decrement = item.SellIn <= 0 ? 2 : 1;
            item.Quality = System.Math.Max(0, item.Quality - decrement);
            item.SellIn--;
        }
    }
}