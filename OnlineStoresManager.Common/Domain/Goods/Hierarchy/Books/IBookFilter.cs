using OnlineStoresManager.Abstractions;

namespace OnlineStoresManager.Goods
{
    internal interface IBookFilter : IPagination
    {
        string? SearchText { get; }
        BookType BookType { get; }
        int SortBy { get; }
        SortOrder SortOrder { get; }
    }
}
