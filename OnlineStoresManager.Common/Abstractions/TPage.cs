using System.Collections.Generic;

namespace OnlineStoresManager.Abstractions
{
    public interface IPage<out T> : IReadOnlyCollection<T>
    {
        int TotalCount { get; }
    }
}
