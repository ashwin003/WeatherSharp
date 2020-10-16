using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class Sys
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonProperty("sunset")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunset { get; set; }
    }
}
