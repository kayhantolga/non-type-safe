using System.Text.Json;
using System.Text.Json.Serialization;

namespace non_type_safe;

public class ComplexTypeConverter : JsonConverter<OtherParameterComplexType>
{
    public override OtherParameterComplexType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
                var integerValue = reader.GetInt64();
                return new() { OtherParameter5 = (int)integerValue };

            case JsonTokenType.String:
                var stringValue = reader.GetString();
                return new() { OtherParameter1 = stringValue };

            case JsonTokenType.StartObject:
                var objectValue = JsonSerializer.Deserialize<OtherParameterInnerClass>(ref reader, options);
                return new() { OtherParameter6 = objectValue };

            case JsonTokenType.StartArray:
                var arrayValue = JsonSerializer.Deserialize<List<string>>(ref reader, options);
                return new() { OtherParameter2 = arrayValue };
        }

        throw new("Cannot unmarshal type OtherParameterUnion");
    }

    public override void Write(Utf8JsonWriter writer, OtherParameterComplexType value, JsonSerializerOptions options)
    {
        var property = value?.GetType()
            .GetProperties()
            .FirstOrDefault(p => p.GetValue(value) != null);

        if (property != null)
        {
            JsonSerializer.Serialize(writer, property.GetValue(value), property.PropertyType, options);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}