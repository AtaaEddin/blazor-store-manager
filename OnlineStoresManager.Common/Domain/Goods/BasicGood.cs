using OnlineStoresManager.Goods.Clothes;
using OnlineStoresManager.Goods.Books;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OnlineStoresManager.Goods
{
    [JsonDerivedType(typeof(ShortStory), typeDiscriminator: (int)GoodType.ShortStory)]
    [JsonDerivedType(typeof(Shirt), typeDiscriminator: (int)GoodType.Shirt)]
    public abstract class BasicGood
    {
        public const string ImageUrlSeparetor = ",";
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public List<string>? ImageUrls { get; set; }
        public string? Description { get; set; }
        public GoodType? Type { get; set; }
        public GoodGategory? Gategory { get; set; }
    }
}
