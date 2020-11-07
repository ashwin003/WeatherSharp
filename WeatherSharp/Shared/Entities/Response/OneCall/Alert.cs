using Newtonsoft.Json;
using System;

namespace WeatherSharp.Shared.Entities.Response.OneCall
{
    [Serializable]
    public class Alert
    {
        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("event")]
        public string EventName { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("description")]
        public string Decsription { get; set; }
    }
}
