using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OnlineStoresManager.Abstractions
{
    public class PagedListJsonConverter<T> : JsonConverter<PagedList<T>>
    {
        public override PagedList<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.EnsureTokenType(JsonTokenType.StartObject);

            reader.Read();
            reader.EnsureTokenType(JsonTokenType.PropertyName);
            reader.EnsurePropertyName(nameof(PagedList<T>.TotalCount));

            reader.Read();
            reader.EnsureTokenType(JsonTokenType.Number);
            int totalCount = reader.GetInt32();

            reader.Read();
            reader.EnsureTokenType(JsonTokenType.PropertyName);
            reader.EnsurePropertyName("Page");

            reader.Read();
            reader.EnsureTokenType(JsonTokenType.StartArray);
            List<T> collection = JsonSerializer.Deserialize<List<T>>(ref reader, options)!;

            reader.Read();
            reader.EnsureTokenType(JsonTokenType.EndObject);

            return new PagedList<T>(collection, totalCount);
        }

        public override void Write(Utf8JsonWriter writer, PagedList<T> list, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(nameof(list.TotalCount), options);
            writer.WriteNumberValue(list.TotalCount);

            writer.WritePropertyName("Page", options);
            writer.WriteStartArray();

            foreach (T item in list)
            {
                JsonSerializer.Serialize(writer, item, options);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }
    }
}
