using System;

namespace WeatherSharp.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class TemperatureScaleAttribute : Attribute
    {
        public TemperatureScaleAttribute(string displayName, string shortName)
        {
            DisplayName = displayName;
            ShortName = shortName;
        }

        public string DisplayName { get; }
        public string ShortName { get; }
    }
}
