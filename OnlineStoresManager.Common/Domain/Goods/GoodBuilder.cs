using System;
using OnlineStoresManager.Goods.Books;
using OnlineStoresManager.Goods.Clothes;

namespace OnlineStoresManager.Goods
{
    public static class GoodBuilder
    {
        public static BasicGood Create(GoodType type)
        {
            switch (type)
            {
                case GoodType.Shirt:
                    return new Shirt();

                case GoodType.ShortStory:
                    return new ShortStory();

                default: throw new ArgumentException($"combination of Type: {type} is not supported");
            }
        }

        public static TGood Create<TGood>()
            where TGood : BasicGood, new()
        {
            switch(typeof(TGood))
            {
                case Type type when type == typeof(ShortStory): return (TGood)Create(GoodType.ShortStory);

                case Type type when type == typeof(Shirt): return (TGood)Create(GoodType.Shirt);

                default: throw new ArgumentException($"Not supported good type {typeof(TGood)}");
            }
        }
    }
}
