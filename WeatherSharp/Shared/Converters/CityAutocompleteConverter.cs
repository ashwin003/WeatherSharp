using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using WeatherSharp.Shared.Entities.Response;

namespace WeatherSharp.Shared.Converters
{
    public class CityAutocompleteConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var geometry = token["geometry"];
            var jsonCoordinates = geometry["coordinates"];
            var coordinates = new Coordinate
            {
                Lattitude = jsonCoordinates.Last.Value<double>(),
                Longitude = jsonCoordinates.First.Value<double>()
            };

            var properties = token["properties"];
            var name = properties.Value<string>("name");
            var state = properties.Value<string>("state");
            var country = properties.Value<string>("country");
            var id = properties.Value<long>("osm_id");

            return new City
            {
                Coordinate = coordinates,
                Country = country,
                Name = name,
                State = state,
                Id = id
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
