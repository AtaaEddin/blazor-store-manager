using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OnlineStoresManager.Goods
{
    [JsonDerivedType(typeof(Book), typeDiscriminator: (int)GoodDiscriminator.Books)]
    [JsonDerivedType(typeof(Shirt), typeDiscriminator: (int)GoodDiscriminator.Shirt)]
    public abstract class BasicGood
    {
        public const string ImageUrlSeparetor = ",";
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public List<string>? ImageUrls { get; set; }
        public string? Description { get; set; }
        public GoodGategory? Gategory { get; set; }
        public GoodDiscriminator? Discriminator { get; set; }
    }
}
