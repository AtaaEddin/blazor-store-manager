using OnlineStoresManager.Goods;
using OnlineStoresManager.Abstractions;

namespace OnlineStoresManager.API.Goods
{
    public static class GoodExtenstion
    {
        public static IQueryable<BasicGood> FilterBy(this IQueryable<BasicGood> goods, IBasicGoodFilter filter)
        {
            switch (filter.Discriminator)
            {
                case GoodDiscriminator.Shirt:
                    return goods
                        .OfType<Shirt>()
                        .FilterByInternal(filter);

                case GoodDiscriminator.Books:
                    return goods
                        .OfType<Book>()
                        .FilterByInternal(filter);

                default: return goods.FilterByInternal<BasicGood>(filter);
            }
        }

        private static IQueryable<TGood> FilterByInternal<TGood>(this IQueryable<TGood> goods, IBasicGoodFilter filter)
            where TGood : BasicGood
        {
            return goods.Where(g =>
                (filter.Discriminator == null || g.Discriminator == filter.Discriminator)
                && (filter.Gategory == null || g.Gategory == filter.Gategory)
                && (filter.MaxPrice == null || g.Price <= filter.MaxPrice)
                && (filter.MinPrice == null || g.Price >= filter.MinPrice)
                    && (filter.SearchText == null
                        || (g.Name != null && g.Name.Contains(filter.SearchText))
                        || (g.Description != null && g.Description.Contains(filter.SearchText!))));
        }

        private static IQueryable<Shirt> FilterByInternal(this IQueryable<Shirt> goods, IBasicGoodFilter filter)
        {
            return goods.FilterByInternal<Shirt>(filter)
                .Where(s => 
                (((ShirtFilter)filter).ShirtType == null ||  s.ShirtType == ((ShirtFilter)filter).ShirtType)
                && (((ShirtFilter)filter).Color == null || s.Color == ((ShirtFilter)filter).Color));
        }

        private static IQueryable<Book> FilterByInternal(this IQueryable<Book> goods, IBasicGoodFilter filter)
        {
            return goods.FilterByInternal<Book>(filter).
                Where(b =>
                (((BookFilter)filter).BookType == null || b.BookType == ((BookFilter)filter).BookType)
                && (filter.SearchText == null || (b.Author != null && b.Author == filter.SearchText)));
        }

        public static IQueryable<BasicGood> SortBy(this IQueryable<BasicGood> goods, IBasicGoodFilter filter)
        {
            switch((BasicGoodFieldIdentifier)filter.SortBy)
            {
                case BasicGoodFieldIdentifier.Discriminator:
                    return goods.OrderBy(g => g.Discriminator, filter.SortOrder);

                case BasicGoodFieldIdentifier.Price:
                    return goods.OrderBy(g => g.Price, filter.SortOrder);

                case BasicGoodFieldIdentifier.Name:
                    return goods.OrderBy(g => g.Name, filter.SortOrder);

                case BasicGoodFieldIdentifier.Category:
                    return goods.OrderBy(g => g.Gategory, filter.SortOrder);

                default: break;
            }

            switch (filter.Discriminator)
            {
                case GoodDiscriminator.Shirt:
                    return goods
                        .OfType<Shirt>()
                        .SortByInternal(filter);

                case GoodDiscriminator.Books:
                    return goods
                        .OfType<Book>()
                        .SortByInternal(filter);

                default: throw new ArgumentException($"Not supported discriminator {filter.Discriminator}");
            }
        }

        private static IQueryable<Shirt> SortByInternal(this IQueryable<Shirt> shirts, IBasicGoodFilter filter)
        {
            switch ((ShirtFieldIdentifier)filter.SortBy)
            {
                case ShirtFieldIdentifier.ShirtType:
                    return shirts.OrderBy(s => s.ShirtType, filter.SortOrder);
                case ShirtFieldIdentifier.Color:
                    return shirts.OrderBy(s => s.Color, filter.SortOrder);

                default:
                    throw new ArgumentException($"Not supported field identifier {filter.SortBy}.");
            }
        }

        private static IQueryable<Book> SortByInternal(this IQueryable<Book> books, IBasicGoodFilter filter)
        {
            switch((BookFieldIdentifier)filter.SortBy)
            {
                case BookFieldIdentifier.BookType:
                    return books.OrderBy(b => b.BookType, filter.SortOrder);
                case BookFieldIdentifier.Author:
                    return books.OrderBy(b => b.Author, filter.SortOrder);

                default:
                    throw new ArgumentException($"Not supported field identifier {filter.SortBy}.");
            }
        }
    }
}
