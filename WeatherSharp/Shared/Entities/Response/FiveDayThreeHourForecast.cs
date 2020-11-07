using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class FiveDayThreeHourForecast
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("cnt")]
        public int NumberOfTimestamps { get; set; }

        [JsonProperty("list")]
        public IEnumerable<FDTHForeCast> Forecasts { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
}
