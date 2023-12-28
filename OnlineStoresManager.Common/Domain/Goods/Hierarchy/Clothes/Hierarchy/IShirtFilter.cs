using OnlineStoresManager.Abstractions;

namespace OnlineStoresManager.Goods.Clothes
{
    public interface IShirtFilter : IBasicGoodFilter, IPagination
    {
        string? Color { get; }
        ShirtType? ShirtType { get; }
    }
}
