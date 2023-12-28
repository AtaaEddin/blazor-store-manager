using OnlineStoresManager.Abstractions;
using System;

namespace OnlineStoresManager.Goods
{
    public interface IBasicGoodFilter : IPagination
    {
        decimal? MaxPrice { get; }
        decimal? MinPrice { get; }
        GoodGategory? Gategory { get; }
        GoodType? Type { get; }
        string? SearchText { get; }
        int SortBy { get; }
        SortOrder SortOrder { get; }
    }
}
