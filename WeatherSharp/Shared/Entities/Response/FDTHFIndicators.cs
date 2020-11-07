using Newtonsoft.Json;
using System;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class FDTHFIndicators : Indicators
    {
        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("sea_level")]
        public int SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public int GroundLevel { get; set; }
    }
}
