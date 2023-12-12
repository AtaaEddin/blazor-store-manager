using OnlineStoresManager.Abstractions;
using System.Linq.Expressions;
using System.Linq;
using System;

namespace OnlineStoresManager.Abstractions
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(
            this IQueryable<TSource> query,
            Expression<Func<TSource, TKey>> keySelector,
            SortOrder order)
        {
            switch (order)
            {
                case SortOrder.Ascending:
                    return query.OrderBy(keySelector);
                case SortOrder.Descending:
                    return query.OrderByDescending(keySelector);
                default:
                    throw new ArgumentException(string.Format("Not supported sort order '{0}'", order));
            }
        }

        public static IQueryable<TProjection> Project<TEntity, TProjection>(this IQueryable<TEntity> query)
            where TProjection : IProjection<TEntity, TProjection>
        {
            return query.Select(TProjection.Projector);
        }

        public static IQueryable<TSource> TakePage<TSource>(this IQueryable<TSource> query, IPagination pagination)
        {
            return query
                .Skip(pagination.PageIndex * pagination.PageSize)
                .Take(pagination.PageSize);
        }

        public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(
            this IOrderedQueryable<TSource> query,
            Expression<Func<TSource, TKey>> keySelector,
            SortOrder order)
        {
            switch (order)
            {
                case SortOrder.Ascending:
                    return query.ThenBy(keySelector);
                case SortOrder.Descending:
                    return query.ThenByDescending(keySelector);
                default:
                    throw new ArgumentException(string.Format("Not supported sort order '{0}'", order));
            }
        }
    }
}
