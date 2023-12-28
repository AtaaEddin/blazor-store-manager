using System.Text.Json.Serialization;

namespace OnlineStoresManager.Goods.Clothes
{
    [JsonDerivedType(typeof(Shirt), typeDiscriminator: (int)GoodType.Shirt)]
    public class Shirt : BasicClothe
    {
        public Shirt()
        {
            Type = GoodType.Shirt;
        }

        public string? Color { get; set; }
        public ShirtType? ShirtType { get; set; }
    }
}
