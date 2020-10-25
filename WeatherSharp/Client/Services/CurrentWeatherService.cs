using System;
using Blazored.LocalStorage;
using System.Threading.Tasks;
using WeatherSharp.Client.Models;
using WeatherSharp.Client.ServiceInterfaces;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Client.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        private readonly IHttpService service;
        private readonly ILocalStorageService localStorageService;

        public CurrentWeatherService(IHttpService service, ILocalStorageService localStorageService)
        {
            this.service = service;
            this.localStorageService = localStorageService;
        }

        public Task<CurrentWeather> GetCurrentWeatherAsync(Coordinate coordinate, Unit unit = Unit.Standard, string lang = "en")
        {
            throw new NotImplementedException();
        }

        public Task<CurrentWeather> GetCurrentWeatherAsync(long cityId, Unit unit = Unit.Standard, string lang = "en")
        {
            throw new NotImplementedException();
        }

        public Task<CurrentWeather> GetCurrentWeatherAsync(long zipCode, string countryCode, Unit unit = Unit.Standard, string lang = "en")
        {
            throw new NotImplementedException();
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(string cityName, Unit unit = Unit.Standard, string lang = "en")
        {
            var intUnit = (int)unit;
            if(await localStorageService.ContainKeyAsync(Constants.LocalStorage.TemperatureScale)) {
                intUnit = await localStorageService.GetItemAsync<int>(Constants.LocalStorage.TemperatureScale);
            }
            var httpResponse = await service.Get<CurrentWeather>($"Weather?city={Uri.EscapeUriString(cityName)}&unit={intUnit}");
            return httpResponse.Response;
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(string cityName, string stateCode, string countryCode, Unit unit = Unit.Standard, string lang = "en")
        {
            var intUnit = (int)unit;
            if(await localStorageService.ContainKeyAsync(Constants.LocalStorage.TemperatureScale)) {
                intUnit = await localStorageService.GetItemAsync<int>(Constants.LocalStorage.TemperatureScale);
            }
            var httpResponse = await service.Get<CurrentWeather>($"Weather?city={Uri.EscapeUriString(cityName)}&state={Uri.EscapeUriString(stateCode)}&country={Uri.EscapeUriString(countryCode)}&unit={unit}");
            return httpResponse.Response;
        }
    }
}
