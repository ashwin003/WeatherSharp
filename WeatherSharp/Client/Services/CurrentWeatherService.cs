using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherSharp.Client.ServiceInterfaces;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Client.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        private readonly IHttpService service;

        public CurrentWeatherService(IHttpService service)
        {
            this.service = service;
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
            var httpResponse = await service.Get<CurrentWeather>($"Weather?city={Uri.EscapeUriString(cityName)}");
            return httpResponse.Response;
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(string cityName, string stateCode, string countryCode, Unit unit = Unit.Standard, string lang = "en")
        {
            var httpResponse = await service.Get<CurrentWeather>($"Weather?city={Uri.EscapeUriString(cityName)}&state={Uri.EscapeUriString(stateCode)}&country={Uri.EscapeUriString(countryCode)}");
            return httpResponse.Response;
        }
    }
}
