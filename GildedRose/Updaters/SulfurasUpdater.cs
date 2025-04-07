namespace GildedRoseKata
{
    public class SulfurasUpdater : IUpdatableItem
    {
        private readonly Item item;

        public SulfurasUpdater(Item item)
        {
            this.item = item;
        }

        public void UpdateItem()
        {
            // Sulfuras does not change in quality or sell-in.
        }
    }
}