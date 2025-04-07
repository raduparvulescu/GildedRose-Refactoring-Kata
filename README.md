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

## Project Structure

I organized the project into the following folders:

GildedRoseKata/
├── Constants/
│   └── ItemNames.cs         // Contains constants for item names
├── Factories/
│   └── UpdaterFactory.cs    // Factory for creating updater instances
├── Interfaces/
│   └── IUpdatableItem.cs     // Interface defining update behavior
├── Models/
│   └── Item.cs              // The legacy Item class (untouched!)
├── Services/
│   └── GildedRose.cs        // Service that delegates update logic to updaters
├── Updaters/
│   ├── NormalItemUpdater.cs     // Updates normal items
│   ├── AgedBrieUpdater.cs       // Updates “Aged Brie”
│   ├── SulfurasUpdater.cs       // Updates “Sulfuras, Hand of Ragnaros”
│   ├── BackstagePassUpdater.cs  // Updates “Backstage passes to a TAFKAL80ETC concert”
│   └── ConjuredItemUpdater.cs   // Updates “Conjured Mana Cake”
└── Program.cs               // Main program that runs the simulation

