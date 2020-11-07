﻿using Newtonsoft.Json;
using System;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class BaseTemperature
    {
        [JsonProperty("day")]
        public double Day { get; set; }

        [JsonProperty("night")]
        public double Night { get; set; }

        [JsonProperty("eve")]
        public double Evening { get; set; }

        [JsonProperty("morn")]
        public double Morning { get; set; }
    }

    [Serializable]
    public class Temperature : BaseTemperature
    {
        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }
    }

    [Serializable]
    public class FeelsLike : BaseTemperature
    {

    }
}
