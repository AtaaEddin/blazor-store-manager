using OnlineStoresManager.Abstractions;
using System;

namespace OnlineStoresManager.Goods
{
    public interface IBasicGoodFilter : IPagination
    {
        GoodDiscriminator? Discriminator { get; }
        string? SearchText { get; }
        int SortBy { get; }
        SortOrder SortOrder { get; }
    }
}
