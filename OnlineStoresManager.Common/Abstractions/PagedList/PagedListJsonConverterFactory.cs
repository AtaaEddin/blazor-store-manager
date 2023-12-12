using System.Text.Json.Serialization;
using System.Text.Json;
using System;

namespace OnlineStoresManager.Abstractions
{
    public class PagedListJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsGenericType
                && typeToConvert.GetGenericTypeDefinition().IsAssignableFrom(typeof(PagedList<>));
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            object converter = Activator.CreateInstance(typeof(PagedListJsonConverter<>).MakeGenericType(typeToConvert.GetGenericArguments()))!;

            return (converter as JsonConverter)!;
        }
    }
}
