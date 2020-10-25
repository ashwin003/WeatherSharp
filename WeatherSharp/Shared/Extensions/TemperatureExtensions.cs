using WeatherSharp.Shared.Attributes;
using WeatherSharp.Shared.Entities.Request;

namespace WeatherSharp.Shared.Extensions
{
    public static class TemperatureExtensions
    {
        public static string ToDisplayString(this double temperature, Unit unit)
        {
            return $"{temperature}°{unit.ToTemperatureUnit()}";
        }

        public static string ToTemperatureUnit(this Unit unit)
        {
            return unit.GetAttributeOfType<TemperatureScaleAttribute>().ShortName.Trim();
        }
    }
}