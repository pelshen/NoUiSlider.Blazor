using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PElshen.NoUiSlider.Blazor.Utilities
{
    internal class PipsModeJsonConverter : JsonConverter<PipsMode>
    {
        public override PipsMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => (PipsMode)Enum.Parse(typeof(PipsMode), reader.GetString());

        public override void Write(Utf8JsonWriter writer, PipsMode value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString().ToLower());
    }
}
