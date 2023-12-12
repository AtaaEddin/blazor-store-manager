using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;

namespace OnlineStoresManager.Common.Domain.Goods.Hierarchy.Clothes
{
    public class ShirtFilter : Pagination, IShirtFilter
    {
        public const int DefaultSortBy = (int)BasicGoodFieldIdentifier.Name;
        public const SortOrder DefaultSortOrder = SortOrder.Ascending;

        public string? SearchText { get; set; }
        public ShirtType? ShirtType { get; set; }
        public string? Color { get; set; }
        public int SortBy { get; set; } = DefaultSortBy;
        public SortOrder SortOrder { get; set; } = DefaultSortOrder;
        public decimal? MaxPrice { set; get; }
        public decimal? MinPrice { set; get; }
        public GoodDiscriminator? Discriminator { set; get; }
        public GoodGategory? Gategory { set; get; }
    }
}
