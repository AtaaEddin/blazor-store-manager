using OnlineStoresManager.Goods;
using System.Text.Json.Serialization;

namespace OnlineStoresManager.Goods.Books
{
    [JsonDerivedType(typeof(ShortStory), typeDiscriminator: (int)GoodType.ShortStory)]
    abstract public class BasicBook : BasicGood
    {
        public BasicBook()
        {
            Gategory = GoodGategory.Books;
        }
        public string? Author { get; set; }
    }
}
