using System.Text.Json;
using System;

namespace OnlineStoresManager.Abstractions
{
    internal static class PagedListJsonExtensions
    {
        public static void EnsurePropertyName(this Utf8JsonReader reader, string propertyName)
        {
            string? jsonString = reader.GetString();

            if (!string.Equals(jsonString, propertyName, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new JsonException("Invalid format");
            }
        }

        public static void EnsureTokenType(this Utf8JsonReader reader, JsonTokenType tokenType)
        {
            if (reader.TokenType != tokenType)
            {
                throw new JsonException("Invalid format");
            }
        }

        public static void WritePropertyName(this Utf8JsonWriter writer, string propertyName, JsonSerializerOptions options)
        {
            string name = propertyName.GetJsonPropertyName(options);

            writer.WritePropertyName(name);
        }

        private static string GetJsonPropertyName(this string propertyName, JsonSerializerOptions options)
        {
            return options?.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName;
        }
    }
}
