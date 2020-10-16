using Newtonsoft.Json;
using System;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class Cloudiness
    {
        [JsonProperty("all")]
        public int Percentage { get; set; }
    }
}
