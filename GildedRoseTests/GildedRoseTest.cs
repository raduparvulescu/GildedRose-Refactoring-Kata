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
    public void TestUpdateQualityLowersSellInValueByOne()
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
    public void TestUpdateQualityLowersQualityValueByOne()
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
    public void TestUpdateQualityLowersQualityTwiceAsFastWhenSellInIsNegative()
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
    public void TestUpdateQualityLowersQualityTwiceAsFastWhenSellInIsZero()
    {
        // Given
        var item = CreateItem("foo", 0, 8);
        var gl = CreateGildedRose(item);
        // When
        gl.UpdateQuality();
        // Then
        Assert.Equal(6, item.Quality);
    }

    private static Item CreateItem(string name, int sellIn, int quality) =>
        new Item { Name = name, SellIn = sellIn, Quality = quality };

    private static GildedRose CreateGildedRose(Item item) =>
        new GildedRose(new List<Item> { item });

}
