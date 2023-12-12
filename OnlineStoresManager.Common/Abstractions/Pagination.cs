namespace OnlineStoresManager.Abstractions
{
    public class Pagination : IPagination
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 20;

        public Pagination() { }

        public Pagination(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public Pagination(Pagination pagination)
            : this(pagination as IPagination) { }

        public Pagination(IPagination pagination)
            : this(pagination.PageIndex, pagination.PageSize) { }
    }
}
