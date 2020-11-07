using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class DailyForecast
    {
        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("cnt")]
        public int NumberOfDays { get; set; }

        [JsonProperty("list")]
        public IEnumerable<Forecast> Forecasts { get; set; }
    }
}
