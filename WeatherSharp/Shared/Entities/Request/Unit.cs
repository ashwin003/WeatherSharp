using WeatherSharp.Shared.Attributes;

namespace WeatherSharp.Shared.Entities.Request
{
    public enum Unit
    {
        [EnumDescription("standard")]
        [TemperatureScale("Kelvin", "K")]
        Standard,
        [EnumDescription("metric")]
        [TemperatureScale("Celcius", "C")]
        Metric,
        [EnumDescription("imperial")]
        [TemperatureScale("Fahrenheit", "F")]
        Imperial
    }
}
