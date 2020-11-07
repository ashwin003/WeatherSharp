using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherSharp.Shared.Entities.Response.OneCall
{
    [Serializable]
    public class Minutely
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("precipitation")]
        public double Precipitation { get; set; }
    }
}
