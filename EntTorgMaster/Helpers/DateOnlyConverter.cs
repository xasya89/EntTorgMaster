using System.Text.Json;
using System.Text.Json.Serialization;

namespace EntTorgMaster.Helpers
{
    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string serializationFormat = "yyyy-MM-dd";
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            DateOnly.TryParse(value, out var result);
            return result;
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString());
    }
}
