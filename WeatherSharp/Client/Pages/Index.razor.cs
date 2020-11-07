using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using WeatherSharp.Client.Models;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Client.Pages
{
    public partial class Index
    {
        public Index()
        {
            Title = "Weather";
        }

        protected override async Task OnInitializedAsync()
        {
            var containsSelectedCity = await localStorageService.ContainKeyAsync(Constants.LocalStorage.City);
            if(containsSelectedCity)
            {
                UpdateDocumentTitle("Loading");
                var city = await localStorageService.GetItemAsync<City>(Constants.LocalStorage.City);
                CurrentWeather = await weatherService.GetCurrentWeatherAsync(city.Name);

                UpdateDocumentTitle(CurrentWeather.CityName);
            }

            await base.OnInitializedAsync();
        }

        private CurrentWeather CurrentWeather;
        private DailyForecast DailyForecast;

        [Inject] private ICurrentWeatherService weatherService { get; set; }
        [Inject] private IDailyForecastService dailyForecastService { get; set; }
        [Inject] private ILocalStorageService localStorageService { get; set; }
    }
}