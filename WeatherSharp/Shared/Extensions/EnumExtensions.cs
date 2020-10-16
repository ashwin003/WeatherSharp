using System;
using WeatherSharp.Shared.Attributes;
using WeatherSharp.Shared.Entities.Request;

namespace WeatherSharp.Shared.Extensions
{
    internal static class EnumExtensions
    {
        internal static string ToDescription(this Unit unit)
        {
            return unit.GetAttributeOfType<EnumDescriptionAttribute>().Description;
        }

        internal static (string DisplayName, string ShortName, Unit unit) ToTemperatureScale(this Unit unit)
        {
            var temperatureScaleAttribute = unit.GetAttributeOfType<TemperatureScaleAttribute>();
            return (temperatureScaleAttribute.DisplayName, temperatureScaleAttribute.ShortName, unit);
        }

        internal static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}
