using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class OneCallResponse
    {
        [JsonProperty("lat")]
        public double Lattitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public long TimezoneOffset { get; set; }

        [JsonProperty("current")]
        public OneCall.CurrentWeather CurrentWeather { get; set; }

        [JsonProperty("minutely")]
        public IEnumerable<OneCall.Minutely> Minutelies { get; set; }

        [JsonProperty("hourly")]
        public IEnumerable<OneCall.Hourly> Hourlies { get; set; }

        [JsonProperty("daily")]
        public IEnumerable<OneCall.Daily> Dailies { get; set; }

        [JsonProperty("alert")]
        public IEnumerable<OneCall.Alert> Alerts { get; set; }
    }
}
