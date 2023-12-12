using System.Text.Json;

namespace OnlineStoresManager.Abstractions
{
    public static class ExpressionExtensions
    {
        public static void AddExpressionConverters(this JsonSerializerOptions options)
        {
            options.Converters.Add(new ExpressionJsonConverterFactory());
        }
    }
}
