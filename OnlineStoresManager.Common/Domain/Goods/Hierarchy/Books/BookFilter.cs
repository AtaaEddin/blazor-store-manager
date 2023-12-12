using OnlineStoresManager.Abstractions;

namespace OnlineStoresManager.Goods
{
    public class BookFilter : Pagination, IBookFilter
    {
        public const int DefaultSortBy = (int)BasicGoodFieldIdentifier.Name;
        public const SortOrder DefaultSortOrder = SortOrder.Ascending;

        public string? SearchText { set; get; }
        public BookType BookType { get; set; }
        public int SortBy { get; set; } = DefaultSortBy;
        public SortOrder SortOrder {  get; set; } = DefaultSortOrder;
    }
}
