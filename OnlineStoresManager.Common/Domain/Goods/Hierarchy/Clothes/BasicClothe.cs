using System.Text.Json.Serialization;

namespace OnlineStoresManager.Goods.Clothes
{
    [JsonDerivedType(typeof(Shirt), typeDiscriminator: (int)GoodType.Shirt)]
    abstract public class BasicClothe : BasicGood
    {
        public BasicClothe()
        {
            Gategory = GoodGategory.Clothes;
        }
    }
}
