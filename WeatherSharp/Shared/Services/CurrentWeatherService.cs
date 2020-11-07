using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.Extensions;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Shared.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        private readonly string weatherEndpoint = "weather";

        private readonly IApiService<CurrentWeather> weatherService;
        public CurrentWeatherService(IApiService<CurrentWeather> weatherService)
        {
            this.weatherService = weatherService;
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(string cityName, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters(cityName, unit, lang);
            var payload = new OWPayload();
            payload.SetParameters(weatherEndpoint, parameters);

            return await UpdateUnit(weatherService.ProcessRequestAsync(payload), unit);
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(string cityName, string stateCode, string countryCode, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters($"{cityName},{stateCode},{countryCode}", unit, lang);
            var payload = new OWPayload();
            payload.SetParameters(weatherEndpoint, parameters);

            return await UpdateUnit(weatherService.ProcessRequestAsync(payload), unit);
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(long cityId, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters(cityId, unit, lang);
            var payload = new OWPayload();
            payload.SetParameters(weatherEndpoint, parameters);

            return await UpdateUnit(weatherService.ProcessRequestAsync(payload), unit);
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(long zipCode, string countryCode, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters(zipCode, countryCode, unit, lang);
            var payload = new OWPayload();
            payload.SetParameters(weatherEndpoint, parameters);

            return await UpdateUnit(weatherService.ProcessRequestAsync(payload), unit);
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(Coordinate coordinate, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters(coordinate, unit, lang);
            var payload = new OWPayload();
            payload.SetParameters(weatherEndpoint, parameters);

            return await UpdateUnit(weatherService.ProcessRequestAsync(payload), unit);
        }

        private async Task<CurrentWeather> UpdateUnit(Task<CurrentWeather> currentWeather, Unit unit)
        {
            var weather = await currentWeather;
            weather.Unit = unit;

            return weather;
        }

        private IEnumerable<Parameter> PrepareParameters(string searchTerm, Unit unit, string lang)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) throw new ArgumentNullException("SearchTermRequired");

            return new[]
            {
                new Parameter { Name = "q", Value = searchTerm },
                new Parameter { Name = "units", Value = unit.ToDescription() },
                new Parameter { Name = "lang", Value = lang }
            };
        }

        private IEnumerable<Parameter> PrepareParameters(long cityId, Unit unit, string lang)
        {
            if (cityId == 0) throw new ArgumentNullException("CityidRequired");

            return new[]
            {
                new Parameter { Name = "id", Value = cityId },
                new Parameter { Name = "units", Value = unit.ToDescription() },
                new Parameter { Name = "lang", Value = lang }
            };
        }

        private IEnumerable<Parameter> PrepareParameters(Coordinate coordinate, Unit unit, string lang)
        {
            if (coordinate == null || (coordinate.Lattitude == 0 && coordinate.Longitude == 0)) throw new ArgumentNullException("CoordincateRequired");

            return new[]
            {
                new Parameter { Name = "lat", Value = coordinate.Lattitude },
                new Parameter { Name = "lon", Value = coordinate.Longitude },
                new Parameter { Name = "units", Value = unit.ToDescription() },
                new Parameter { Name = "lang", Value = lang }
            };
        }

        private IEnumerable<Parameter> PrepareParameters(long zipCode, string countryCode, Unit unit, string lang)
        {
            if (zipCode == 0 || string.IsNullOrWhiteSpace(countryCode)) throw new ArgumentNullException("RequiredParameterMissing");

            return new[]
            {
                new Parameter { Name = "zip", Value = $"{zipCode},{countryCode}" },
                new Parameter { Name = "units", Value = unit.ToDescription() },
                new Parameter { Name = "lang", Value = lang }
            };
        }
    }
}
