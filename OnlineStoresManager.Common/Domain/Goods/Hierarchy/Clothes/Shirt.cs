using System.Text.Json.Serialization;

namespace OnlineStoresManager.Goods
{
    [JsonDerivedType(typeof(Shirt), typeDiscriminator: (int)GoodDiscriminator.Clothes)]
    public class Shirt : BasicGood
    {
        public Shirt()
        {
            Discriminator = GoodDiscriminator.Clothes;
        }
        public string? Color { get; set; }
        public ShirtType ShirtType { get; set; }
    }
}
