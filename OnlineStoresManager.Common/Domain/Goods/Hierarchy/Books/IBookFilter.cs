using OnlineStoresManager.Abstractions;

namespace OnlineStoresManager.Goods
{
    internal interface IBookFilter : IBasicGoodFilter, IPagination
    {
        BookType? BookType { get; }
    }
}
