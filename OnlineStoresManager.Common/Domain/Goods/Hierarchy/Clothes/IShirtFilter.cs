using OnlineStoresManager.Abstractions;

namespace OnlineStoresManager.Goods
{
    public interface IShirtFilter : IPagination
    {
        string? SearchText { get; }
        ShirtType ShirtType { get; }
        int SortBy { get; }
        SortOrder SortOrder { get; }
    }
}
