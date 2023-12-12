using OnlineStoresManager.Abstractions;

namespace OnlineStoresManager.Goods
{
    public class BasicGoodFilter : Pagination, IBasicGoodFilter
    {
        public const int DefaultSortBy = (int)BasicGoodFieldIdentifier.Name;
        public const SortOrder DefaultSortOrder = SortOrder.Ascending;

        public GoodDiscriminator? Discriminator {  get; set; }
        public GoodGategory? Gategory { get; set; }
        public string? SearchText { set; get; }
        public int SortBy { set; get; } = DefaultSortBy;
        public SortOrder SortOrder {  set; get; } = DefaultSortOrder;
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
    }
}
