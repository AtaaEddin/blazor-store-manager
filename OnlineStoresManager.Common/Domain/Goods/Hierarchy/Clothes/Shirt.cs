using System.Text.Json.Serialization;

namespace OnlineStoresManager.Goods
{
    [JsonDerivedType(typeof(Shirt), typeDiscriminator: (int)GoodDiscriminator.Shirt)]
    public class Shirt : BasicGood
    {
        public Shirt()
        {
            Discriminator = GoodDiscriminator.Shirt;
        }
        public string? Color { get; set; }
        public ShirtType? ShirtType { get; set; }
    }
}
