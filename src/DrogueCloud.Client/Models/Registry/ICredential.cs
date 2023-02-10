using System.Text.Json;
using System.Text.Json.Serialization;

namespace DrogueCloud.Client.Models.Registry;

[JsonConverter(typeof(JsonConverter))]
public interface ICredential
{
    public class JsonConverter : JsonConverter<ICredential>
    {
        private static readonly JsonEncodedText User = JsonEncodedText.Encode("user");
        private static readonly JsonEncodedText Pass = JsonEncodedText.Encode("pass");
        private static readonly JsonEncodedText Cert = JsonEncodedText.Encode("cert");
        private static readonly JsonEncodedText Key = JsonEncodedText.Encode("key");

        public override ICredential? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var type = FindType(reader);
            return (ICredential?)JsonSerializer.Deserialize(ref reader, type, options);
        }

        private static Type FindType(Utf8JsonReader reader)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    if (reader.ValueTextEquals(User.EncodedUtf8Bytes))
                    {
                        return typeof(UserCredential);
                    }
                    else if (reader.ValueTextEquals(Pass.EncodedUtf8Bytes))
                    {
                        return typeof(PassCredential);
                    }
                    else if (reader.ValueTextEquals(Cert.EncodedUtf8Bytes))
                    {
                        return typeof(CertCredential);
                    }
                    else if (reader.ValueTextEquals(Key.EncodedUtf8Bytes))
                    {
                        return typeof(PSKCredential);
                    }
                }
            }

            throw new JsonException("Unable to determine credential type");
        }

        public override void Write(Utf8JsonWriter writer, ICredential value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
