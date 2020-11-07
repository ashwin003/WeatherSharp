using Microsoft.AspNetCore.Components;
using WeatherSharp.Shared.Entities.Response;

namespace WeatherSharp.Client.Shared
{
    public partial class DailyForecastWidget
    {
        [Parameter]
        public DailyForecast Forecast
        {
            get;
            set;
        }
    }
}
