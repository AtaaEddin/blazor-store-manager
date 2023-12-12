using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;

namespace OnlineStoresManager.Common.Domain.Goods.Hierarchy.Clothes
{
    public class ShirtFilter : Pagination, IShirtFilter
    {
        public const int DefaultSortBy = (int)BasicGoodFieldIdentifier.Name;
        public const SortOrder DefaultSortOrder = SortOrder.Ascending;

        public string? SearchText { get; set; }

        public ShirtType ShirtType { get; set; }

        public int SortBy { get; set; } = DefaultSortBy;

        public SortOrder SortOrder { get; set; } = DefaultSortOrder;
    }
}
