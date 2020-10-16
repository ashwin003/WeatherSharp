using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WeatherSharp.Shared.Converters;

namespace WeatherSharp.Shared.Entities.Response
{
    [Serializable]
    public class CityAutocompleteResponse
    {
        [JsonProperty("features", ItemConverterType = typeof(CityAutocompleteConverter))]
        public IEnumerable<City> Cities { get; set; }
    }
}
