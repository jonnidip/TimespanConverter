using Newtonsoft.Json;
using System;

namespace Jonnidip
{
    public class TimespanConverter : JsonConverter<TimeSpan>
    {
        public const string TimeSpanFormatString = @"d\.hh\:mm\:ss\:FFF";

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
            => writer.WriteValue(value.ToString(TimeSpanFormatString));

        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
            => reader.Value != null
                ? TimeSpan.ParseExact((string)reader.Value, TimeSpanFormatString, null)
                : new TimeSpan();
    }
}