using System;
using System.Text.Json.Serialization;

namespace OnlineStoresManager.Goods
{
    [JsonDerivedType(typeof(Book), typeDiscriminator: (int)GoodDiscriminator.Books)]
    [JsonDerivedType(typeof(Shirt), typeDiscriminator: (int)GoodDiscriminator.Clothes)]
    public abstract class BasicGood
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public GoodType Type { get; set; }
        public GoodDiscriminator Discriminator { get; set; }
    }
}
