using System.Text.Json.Serialization;

namespace OnlineStoresManager.Goods.Books
{
    [JsonDerivedType(typeof(ShortStory), typeDiscriminator: (int)GoodType.ShortStory)]
    public class ShortStory : BasicBook
    {
        public ShortStory()
        {
            Type = GoodType.ShortStory;
        }
    }
}
