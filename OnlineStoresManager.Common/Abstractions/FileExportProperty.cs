using System;
using System.Linq.Expressions;

namespace OnlineStoresManager.Abstractions
{
    public class FileExportProperty<TEntity>
    {
        public Expression<Func<TEntity, object?>> Selector { get; }
        public Expression<Func<TEntity, string>> Template { get; }
        public string Title { get; }

        public FileExportProperty(
            Expression<Func<TEntity, object?>> selector,
            Expression<Func<TEntity, string>> template,
            string title)
        {
            Selector = selector;
            Template = template;
            Title = title;
        }
    }
}
