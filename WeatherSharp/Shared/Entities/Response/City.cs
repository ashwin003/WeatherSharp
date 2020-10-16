using Newtonsoft.Json;
using System;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class City
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public Coordinate Coordinate { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        public bool IsDefault { get; set; }
    }
}
