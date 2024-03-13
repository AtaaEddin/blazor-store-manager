using OnlineStoresManager.Goods;
using System;

namespace OnlineStoresManager.Abstractions
{
    public record ImageMetadata
    {
        public required string UserName { get; set; }
        public GoodGategory Gategory { get; set; }
        public GoodType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Format { get; set; }
    }
}
