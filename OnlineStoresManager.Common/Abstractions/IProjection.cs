using System.Linq.Expressions;
using System;

namespace OnlineStoresManager.Abstractions
{
    public interface IProjection<TEntity, TProjection>
    {
        static abstract Expression<Func<TEntity, TProjection>> Projector { get; }
    }
}
