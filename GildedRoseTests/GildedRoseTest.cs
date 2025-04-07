using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    // At the end of each day our system lowers both values for every item
    [Fact]
    public void TestSystemLowersSellInAtEOD()
    {
        // Given
        var item = CreateItem("foo", 2, 2);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(1, item.SellIn);
    }

    [Fact]
    public void TestSystemLowersQualityAtEOD()
    {
        // Given
        var item = CreateItem("foo", 2, 2);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(1, item.Quality);
    }

    // Once the sell by date has passed, Quality degrades twice as fast
    [Fact]
    public void TestQualityDegradesTwiceAsFastForSellInNegative()
    {
        // Given
        var item = CreateItem("foo", -1, 8);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(6, item.Quality);
    }

    [Fact]
    public void TestQualityDegradesTwiceAsFastForSellIn0()
    {
        // Given
        var item = CreateItem("foo", 0, 8);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(6, item.Quality);
    }

    // The Quality of an item is never negative
    [Fact]
    public void TestQualityIsNeverNegative()
    {
        // Given
        var item = CreateItem("foo", 4, 0);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(0, item.Quality);
    }

    // "Aged Brie" actually increases in Quality the older it gets
    [Fact]
    public void TestAgedBrieItemIncreasesInQualityTheOlderItGets()
    {
        // Given
        var item = CreateItem("Aged Brie", 4, 4);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(5, item.Quality);
    }

    // The Quality of an item is never more than 50
    [Fact]
    public void TestQualityIsNeverMoreThan50()
    {
        // Given
        var item = CreateItem("Aged Brie", 5, 50);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(50, item.Quality);
    }

    // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    [Fact]
    public void TestSulfurasNeverDecreasesInQualityOrSellIn()
    {
        // Given
        var item = CreateItem("Sulfuras, Hand of Ragnaros", 5, 80);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(5, item.SellIn);
        Assert.Equal(80, item.Quality);
    }

    // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
    //      Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
    //      Quality drops to 0 after the concert
    [Fact]
    public void TestBackstagePassesIncreasesInQualityBy1WhenMoreThan10Days()
    {
        // Given
        var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 11, 20);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(21, item.Quality);
    }

    [Fact]
    public void TestBackstagePassesIncreasesInQualityBy2When10DaysOrLess()
    {
        // Given
        var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, 20);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void TestBackstagePassesIncreasesInQualityBy3When5DaysOrLess()
    {
        // Given
        var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 20);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(23, item.Quality);
    }

    [Fact]
    public void TestBackstagePassesQualityDropsTo0AfterConcert()
    {
        // Given
        var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 0, 20);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(0, item.Quality);
    }

    // Just for clarification, an item can never have its Quality increase above 50,
    // however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
    [Fact]
    public void TestSulfurasQualityIs80AndNeverChanges()
    {
        // Given
        var item = CreateItem("Sulfuras, Hand of Ragnaros", 5, 80);
        var gl = CreateGildedRose(item);

        // When
        gl.UpdateQuality();

        // Then
        Assert.Equal(80, item.Quality);

        // When updated multiple times
        gl.UpdateQuality();
        gl.UpdateQuality();

        // Then still 80
        Assert.Equal(80, item.Quality);
    }

    // "Conjured" items degrade in Quality twice as fast as normal items
    [Fact]
    public void TestConjuredItemsDegradeInQualityTwiceAsFast()
    {
        // Given
        var item = CreateItem("Conjured Mana Cake", 5, 10);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(8, item.Quality);
    }

    private static Item CreateItem(string name, int sellIn, int quality) =>
        new Item { Name = name, SellIn = sellIn, Quality = quality };

    private static GildedRose CreateGildedRose(Item item) =>
        new GildedRose(new List<Item> { item });

}
