using System.Text.Json.Serialization;

namespace OnlineStoresManager.Goods
{
    [JsonDerivedType(typeof(Book), typeDiscriminator: (int)GoodDiscriminator.Books)]
    public class Book : BasicGood
    {
        public Book()
        {
            Discriminator = GoodDiscriminator.Books;
        }
        public string? Author { get; set; }
        public BookType? BookType { get; set; }
    }
}
