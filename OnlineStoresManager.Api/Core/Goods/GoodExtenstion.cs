using OnlineStoresManager.Goods;
using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods.Clothes;
using OnlineStoresManager.Goods.Books;

namespace OnlineStoresManager.API.Goods
{
    public static class GoodExtenstion
    {
        public static IQueryable<BasicGood> FilterBy(this IQueryable<BasicGood> goods, IBasicGoodFilter filter)
        {
            switch (filter.Type)
            {
                case GoodType.Shirt:
                    return goods
                        .OfType<Shirt>()
                        .FilterByInternal(filter);

                case GoodType.ShortStory:
                    return goods
                        .OfType<ShortStory>()
                        .FilterByInternal(filter);

                case null: return goods;

                default: return goods.FilterByInternal<BasicGood>(filter);
            }
        }

        private static IQueryable<TGood> FilterByInternal<TGood>(this IQueryable<TGood> goods, IBasicGoodFilter filter)
            where TGood : BasicGood
        {
            return goods.Where(g =>
                (filter.Gategory == null || g.Gategory == filter.Gategory)
                && (filter.Type == null || g.Type == filter.Type)
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

        private static IQueryable<ShortStory> FilterByInternal(this IQueryable<ShortStory> goods, IBasicGoodFilter filter)
        {
            return goods.FilterByInternal<ShortStory>(filter).
                Where(b =>
                (filter.SearchText == null || (b.Author != null && b.Author == filter.SearchText)));
        }

        public static IQueryable<BasicGood> SortBy(this IQueryable<BasicGood> goods, IBasicGoodFilter filter)
        {
            switch((BasicGoodFieldIdentifier)filter.SortBy)
            {
                case BasicGoodFieldIdentifier.Gategory:
                    return goods.OrderBy(g => g.Gategory, filter.SortOrder);

                // Note: converting to double when using sqlite because sort by decimal is not supported
                case BasicGoodFieldIdentifier.Price:
                    return goods.OrderBy(g => g.Price != null ? (double)g.Price : 0, filter.SortOrder);

                case BasicGoodFieldIdentifier.Name:
                    return goods.OrderBy(g => g.Name, filter.SortOrder);

                case BasicGoodFieldIdentifier.Type:
                    return goods.OrderBy(g => g.Type, filter.SortOrder);

                default: break;
            }

            switch (filter.Type)
            {
                case GoodType.Shirt:
                    return goods
                        .OfType<Shirt>()
                        .SortByInternal(filter);

                case GoodType.ShortStory:
                    return goods
                        .OfType<ShortStory>()
                        .SortByInternal(filter);

                case null: return goods;

                default: throw new ArgumentException($"Not supported type {filter.Type}");
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

        private static IQueryable<ShortStory> SortByInternal(this IQueryable<ShortStory> books, IBasicGoodFilter filter)
        {
            switch((ShortStoryFieldIdentifier)filter.SortBy)
            {
                case ShortStoryFieldIdentifier.Author:
                    return books.OrderBy(b => b.Author, filter.SortOrder);

                default:
                    throw new ArgumentException($"Not supported field identifier {filter.SortBy}.");
            }
        }
    }
}
