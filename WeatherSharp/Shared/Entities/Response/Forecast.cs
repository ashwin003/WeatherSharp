using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class Forecast
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("sunrise")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonProperty("sunset")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunset { get; set; }

        [JsonProperty("temp")]
        public Temperature Temperature { get; set; }

        [JsonProperty("feels_like")]
        public FeelsLike Feels { get; set; }

        [JsonProperty("weather")]
        public IEnumerable<Weather> Weather { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public int Degree { get; set; }

        [JsonProperty("clouds")]
        public int Clouds { get; set; }
    }
}
