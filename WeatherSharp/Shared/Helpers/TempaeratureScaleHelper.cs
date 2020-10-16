using System;
using System.Collections.Generic;
using System.Linq;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Extensions;

namespace WeatherSharp.Shared.Helpers
{
    public static class TempaeratureScaleHelper
    {
        public static IEnumerable<(string DisplayName, string ShortName, Unit Unit)> GetAvailableTemperatureScales()
        {
            var availableOptions = Enum.GetValues(typeof(Unit)).Cast<Unit>();
            return availableOptions.Select(option => option.ToTemperatureScale());
        }
    }
}
