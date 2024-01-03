using OnlineStoresManager.Abstractions;

namespace OnlineStoresManager.Goods.Clothes
{
    public class ShirtFilter : BasicGoodFilter, IShirtFilter
    {
        public ShirtType? ShirtType { get; set; }
        public string? Color { get; set; }
    }
}
