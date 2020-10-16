using Newtonsoft.Json;
using System;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class Coordinate
    {
        [JsonProperty("lat")]
        public double Lattitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}
