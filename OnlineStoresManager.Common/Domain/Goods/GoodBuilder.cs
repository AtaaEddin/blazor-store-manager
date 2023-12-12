using System;

namespace OnlineStoresManager.Goods
{
    public static class GoodBuilder
    {
        public static BasicGood Create(GoodDiscriminator Discriminator)
        {
            switch (Discriminator)
            {
                case GoodDiscriminator.Books: return new Book();
                case GoodDiscriminator.Shirt: return new Shirt();
                default: throw new ArgumentException($"Not supported good type {nameof(Discriminator)}");
            }
        }

        public static TGood Create<TGood>()
            where TGood : BasicGood, new()
        {
            switch(typeof(TGood))
            {
                case Type type when type == typeof(Book): return (TGood)Create(GoodDiscriminator.Books);
                case Type type when type == typeof(Shirt): return (TGood)Create(GoodDiscriminator.Shirt);
                default: throw new ArgumentException($"Not supported good type {typeof(TGood)}");
            }
        }
    }
}
