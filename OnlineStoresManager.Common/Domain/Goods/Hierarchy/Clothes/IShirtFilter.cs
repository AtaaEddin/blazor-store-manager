using OnlineStoresManager.Abstractions;

namespace OnlineStoresManager.Goods
{
    public interface IShirtFilter : IBasicGoodFilter, IPagination
    {
        string? Color { get; }
        ShirtType? ShirtType { get; }
    }
}
