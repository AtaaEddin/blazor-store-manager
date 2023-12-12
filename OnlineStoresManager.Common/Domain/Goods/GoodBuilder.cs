using System;

namespace OnlineStoresManager.Goods
{
    public static class GoodBuilder
    {
        public static BasicGood Create(GoodDiscriminator Discriminator)
        {
            switch (Discriminator)
            {
                //case GoodDiscriminator.Clothes: return new BasicGood();
                //case GoodDiscriminator.Books: return new BasicGood();
                //case GoodDiscriminator.Digital: return new BasicGood();
                default: throw new ArgumentException($"Not supported good type {nameof(Discriminator)}");
            }
        }

        public static TGood Create<TGood>()
            where TGood : BasicGood, new()
        {
            switch(typeof(TGood))
            {
                //case Type type when type == typeof(Clothes):
                default: throw new ArgumentException($"Not supported good type {typeof(TGood)}");
            }
        }
    }
}
