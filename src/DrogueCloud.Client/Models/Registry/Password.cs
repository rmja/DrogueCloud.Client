using System.Text.Json;
using System.Text.Json.Serialization;

namespace DrogueCloud.Client.Models.Registry;

/// <summary>
/// A password, either plain or hashed.
/// </summary>
[JsonConverter(typeof(JsonConverter))]
public readonly record struct Password
{
    public string? Value { get; }
    public string? Plain { get; }
    public string? BCrypt { get; }
    public string? Sha512 { get; }

    private Password(string? value = null, string? plain = null, string? bCrypt = null, string? sha256 = null)
    {
        Value = value;
        Plain = plain;
        BCrypt = bCrypt;
        Sha512 = sha256;
    }

    public static implicit operator Password(string value) => new(value: value);

    public static Password FromPlain(string value) => new(plain: value);
    public static Password FromBCrypt(string value) => new(bCrypt: value);
    public static Password FromSha512(string value) => new(sha256: value);

    public bool IsValidPassword(string password)
    {
        if (Value == password || Plain == password)
        {
            return true;
        }
        else if (BCrypt is not null)
        {
            //return BC.EnhancedVerify(password, BCrypt);
            throw new NotImplementedException();
        }
        else if (Sha512 is not null)
        {
            //var passwordBytes = Encoding.ASCII.GetBytes(password);
            //var sha512 = SHA512.HashData(passwordBytes);
            throw new NotImplementedException();
        }
        return false;
    }

    public class JsonConverter : JsonConverter<Password>
    {
        private static readonly JsonEncodedText Plain = JsonEncodedText.Encode("plain");
        private static readonly JsonEncodedText BCrypt = JsonEncodedText.Encode("bcrypt");
        private static readonly JsonEncodedText Sha512 = JsonEncodedText.Encode("sha512");

        public override Password Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return reader.GetString()!;
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                Password password;

                reader.Read();
                if (reader.ValueTextEquals(Plain.EncodedUtf8Bytes))
                {
                    password = FromPlain(reader.GetString()!);
                }
                else if (reader.ValueTextEquals(BCrypt.EncodedUtf8Bytes))
                {
                    password = FromBCrypt(reader.GetString()!);
                }
                else if (reader.ValueTextEquals(Sha512.EncodedUtf8Bytes))
                {
                    password = FromSha512(reader.GetString()!);
                }
                else
                {
                    throw new JsonException("Unable to determine password type");
                }
                reader.Read(); // Read EndObject

                return password;
            }

            throw new JsonException("Unable to determine password type");
        }

        public override void Write(Utf8JsonWriter writer, Password value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
