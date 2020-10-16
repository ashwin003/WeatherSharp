using Microsoft.AspNetCore.Components;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;

namespace WeatherSharp.Client.Shared
{
    public partial class WeatherWidget
    {
        [Parameter]
        public CurrentWeather Weather
        {
            get;
            set;
        }
    }
}