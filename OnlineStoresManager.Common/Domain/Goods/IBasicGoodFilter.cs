using OnlineStoresManager.Abstractions;
using System;

namespace OnlineStoresManager.Goods
{
    public interface IBasicGoodFilter : IPagination
    {
        decimal? MaxPrice { get; }
        decimal? MinPrice { get; }
        GoodDiscriminator? Discriminator { get; }
        GoodGategory? Gategory { get; }
        string? SearchText { get; }
        int SortBy { get; }
        SortOrder SortOrder { get; }
    }
}
