using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;

public class ObjectMapJsonConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert.BaseType == typeof(Dictionary<string, JsonElement>);

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var propertyMap = typeToConvert
            .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.DeclaredOnly)
            .ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);

        var converterType = typeof(ObjectMapJsonConverter<>).MakeGenericType(typeToConvert);
        var converter = (JsonConverter)Activator.CreateInstance(converterType, propertyMap)!;
        return converter;
    }
}

public class ObjectMapJsonConverter<T> : JsonConverter<T> where T : Dictionary<string, JsonElement>, new()
{
    private readonly Dictionary<string, PropertyInfo> _propertyMap;

    public ObjectMapJsonConverter(Dictionary<string, PropertyInfo> propertyMap)
    {
        _propertyMap = propertyMap;
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = new T();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString()!;
                if (_propertyMap.TryGetValue(propertyName, out var property))
                {
                    var value = JsonSerializer.Deserialize(ref reader, property.PropertyType, options);
                    property.SetValue(result, value);
                }
                else
                {
                    result[propertyName] = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
                }
            }
            else if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
