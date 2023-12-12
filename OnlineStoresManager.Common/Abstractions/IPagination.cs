namespace OnlineStoresManager.Abstractions
{
    public interface IPagination
    {
        int PageIndex { get; }
        int PageSize { get; }
    }
}
