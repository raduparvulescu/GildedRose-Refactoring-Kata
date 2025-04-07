# Gilded Rose Kata - Polymorphic Refactoring

This is my solution to the Gilded Rose Kata. I needed to update the quality of various items without touching the goblin’s sacred `Item` class—nobody wants to get on his bad side! Instead, I used polymorphism to handle different update behaviors in a neat and scalable way.

## What I Did

- Created an interface (`IUpdatableItem`) that defines the update behavior.
- Implemented specialized updater classes for each item type:
  - **NormalItemUpdater** for regular items.
  - **AgedBrieUpdater** for "Aged Brie".
  - **SulfurasUpdater** for "Sulfuras, Hand of Ragnaros".
  - **BackstagePassUpdater** for "Backstage passes to a TAFKAL80ETC concert".
  - **ConjuredItemUpdater** for "Conjured Mana Cake".
- Developed an `UpdaterFactory` to select the appropriate updater based on the item name.
- Moved shared constants like item names into a dedicated `ItemNames.cs` file.
- Kept the original `Item` class untouched so as not to upset the grumpy goblin.
