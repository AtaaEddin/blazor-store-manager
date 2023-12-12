using System;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace OnlineStoresManager.Abstractions
{
    public class ExpressionJsonConverter<T> : JsonConverter<Expression<T>>
    {
        public override Expression<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetExpression<T>();
        }

        public override void Write(Utf8JsonWriter writer, Expression<T> expression, JsonSerializerOptions options)
        {
            writer.WriteExpression(expression);
        }
    }
}
