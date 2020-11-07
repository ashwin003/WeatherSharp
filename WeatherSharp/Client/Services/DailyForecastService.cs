using Blazored.LocalStorage;
using System;
using System.Threading.Tasks;
using WeatherSharp.Client.Models;
using WeatherSharp.Client.ServiceInterfaces;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Client.Services
{
    public class DailyForecastService : IDailyForecastService
    {
        private readonly IHttpService service;
        private readonly ILocalStorageService localStorageService;

        public DailyForecastService(IHttpService service, ILocalStorageService localStorageService)
        {
            this.service = service;
            this.localStorageService = localStorageService;
        }

        public async Task<DailyForecast> GetWeatherForecastAsync(string cityName, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en")
        {
            var intUnit = (int)unit;
            if (await localStorageService.ContainKeyAsync(Constants.LocalStorage.TemperatureScale))
            {
                intUnit = await localStorageService.GetItemAsync<int>(Constants.LocalStorage.TemperatureScale);
            }

            var httpResponse = await service.Get<DailyForecast>($"DailyForecast?city={Uri.EscapeUriString(cityName)}&numberOfDays={numberOfDays}&unit={intUnit}");
            return httpResponse.Response;
        }

        public async Task<DailyForecast> GetWeatherForecastAsync(string cityName, string stateCode, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en")
        {
            var intUnit = (int)unit;
            if (await localStorageService.ContainKeyAsync(Constants.LocalStorage.TemperatureScale))
            {
                intUnit = await localStorageService.GetItemAsync<int>(Constants.LocalStorage.TemperatureScale);
            }

            var httpResponse = await service.Get<DailyForecast>($"DailyForecast?city={Uri.EscapeUriString(cityName)}&state={Uri.EscapeUriString(stateCode)}&numberOfDays={numberOfDays}&unit={unit}");
            return httpResponse.Response;
        }

        public async Task<DailyForecast> GetWeatherForecastAsync(string cityName, string stateCode, string countryCode, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en")
        {
            var intUnit = (int)unit;
            if (await localStorageService.ContainKeyAsync(Constants.LocalStorage.TemperatureScale))
            {
                intUnit = await localStorageService.GetItemAsync<int>(Constants.LocalStorage.TemperatureScale);
            }

            var httpResponse = await service.Get<DailyForecast>($"DailyForecast?city={Uri.EscapeUriString(cityName)}&state={Uri.EscapeUriString(stateCode)}&country={Uri.EscapeUriString(countryCode)}&numberOfDays={numberOfDays}&unit={unit}");
            return httpResponse.Response;
        }

        public Task<DailyForecast> GetWeatherForecastAsync(long cityId, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en")
        {
            throw new NotImplementedException();
        }

        public Task<DailyForecast> GetWeatherForecastAsync(Coordinate coordinate, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en")
        {
            throw new NotImplementedException();
        }

        public Task<DailyForecast> GetWeatherForecastAsync(long zipCode, string countryCode, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en")
        {
            throw new NotImplementedException();
        }
    }
}
