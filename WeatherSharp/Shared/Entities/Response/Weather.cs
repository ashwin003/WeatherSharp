using Newtonsoft.Json;
using System;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("main")]
        public string Main { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("icon")]
        public string Icon { get; set; } = string.Empty;

        public string IconUrl { 
            get
            {
                return $"//openweathermap.org/img/w/{Icon}.png";
            }
        }

        public string LargeIconUrl
        {
            get
            {
                return $"//openweathermap.org/img/wn/{Icon}@2x.png";
            }
        }
    }
}
