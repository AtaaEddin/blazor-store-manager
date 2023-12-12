using System.Linq.Expressions;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

namespace OnlineStoresManager.Abstractions
{
    public class ExpressionJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsGenericType
                && typeToConvert.GetGenericTypeDefinition().IsAssignableFrom(typeof(Expression<>));
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            object converter = Activator.CreateInstance(typeof(ExpressionJsonConverter<>).MakeGenericType(typeToConvert.GetGenericArguments()))!;

            return (converter as JsonConverter)!;
        }
    }
}
