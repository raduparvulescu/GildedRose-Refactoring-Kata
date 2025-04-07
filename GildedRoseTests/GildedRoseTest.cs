﻿using Xunit;
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

    // The Quality of an item is never negative
    [Fact]
    public void TestUpdateQualityDoesNotLowerQualityBelowZero()
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
    public void TestUpdateQualityIncreasesQualityForAgedBrieItems()
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
    public void TestUpdateQualityDoesNotUpdateQualityBeyond50()
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
    private static Item CreateItem(string name, int sellIn, int quality) =>
        new Item { Name = name, SellIn = sellIn, Quality = quality };

    private static GildedRose CreateGildedRose(Item item) =>
        new GildedRose(new List<Item> { item });

}
