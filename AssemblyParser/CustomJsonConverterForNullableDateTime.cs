using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AssemblyDataParser
{
    public  class CustomJsonConverterForNullableDateTime : JsonConverter<DateTime?>
    {

        #region Overrides of JsonConverter<DateTime?>

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var data = reader.GetString();
            if (string.IsNullOrWhiteSpace(data))
                return null;
            if (data.ToDateTime(out var date_time))
                return date_time;

            return null;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteStringValue("");
            }
            else
            {
                writer.WriteStringValue(value.Value);
            }
        }

        #endregion
    }
}