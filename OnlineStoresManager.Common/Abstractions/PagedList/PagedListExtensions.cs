using System.Text.Json;

namespace OnlineStoresManager.Abstractions
{
    public static class PagedListExtensions
    {
        public static void AddPagedListConverters(this JsonSerializerOptions options)
        {
            options.Converters.Add(new PagedListJsonConverterFactory());
        }
    }
}
