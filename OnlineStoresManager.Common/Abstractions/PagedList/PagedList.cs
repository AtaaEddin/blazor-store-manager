using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoresManager.Abstractions
{
    public class PagedList<T> : List<T>, IPage<T>
    {
        public int TotalCount { get; }

        public PagedList(IEnumerable<T> collection, int totalCount)
            : base(collection)
        {
            TotalCount = totalCount;
        }
    }
}
