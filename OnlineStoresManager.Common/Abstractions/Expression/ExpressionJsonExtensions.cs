using Serialize.Linq.Serializers;
using System.Linq.Expressions;
using System.Text.Json;

namespace OnlineStoresManager.Abstractions
{
    internal static class ExpressionJsonExtensions
    {
        public static Expression<T>? GetExpression<T>(this Utf8JsonReader reader)
        {
            ExpressionSerializer serializer = CreateSerializer();
            string? expressionText = reader.GetString();
            Expression<T>? expression = serializer.DeserializeText(expressionText) as Expression<T>;

            return expression;
        }

        public static void WriteExpression<T>(this Utf8JsonWriter writer, Expression<T> expression)
        {
            ExpressionSerializer serializer = CreateSerializer();
            string expressionText = serializer.SerializeText(expression);
            writer.WriteStringValue(expressionText);
        }

        private static ExpressionSerializer CreateSerializer()
        {
            return new ExpressionSerializer(new Serialize.Linq.Serializers.JsonSerializer());
        }
    }
}
