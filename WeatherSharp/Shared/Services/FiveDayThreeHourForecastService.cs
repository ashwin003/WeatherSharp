using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.Extensions;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Shared.Services
{
    public class FiveDayThreeHourForecastService : IFiveDayThreeHourForecastService
    {
        private readonly string forecastEndpoint = "forecast";
        private readonly IApiService<FiveDayThreeHourForecast> forecastService;

        public FiveDayThreeHourForecastService(IApiService<FiveDayThreeHourForecast> forecastService)
        {
            this.forecastService = forecastService;
        }

        public async Task<FiveDayThreeHourForecast> GetWeatherForecastsAsync(string cityName, int numberOfTimestamps, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters(cityName, unit, numberOfTimestamps, lang);
            var payload = new OWPayload();
            payload.SetParameters(forecastEndpoint, parameters);

            return await forecastService.ProcessRequestAsync(payload);
        }

        public async Task<FiveDayThreeHourForecast> GetWeatherForecastsAsync(string cityName, string stateCode, int numberOfTimestamps, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters($"{cityName},{stateCode}", unit, numberOfTimestamps, lang);
            var payload = new OWPayload();
            payload.SetParameters(forecastEndpoint, parameters);

            return await forecastService.ProcessRequestAsync(payload);
        }

        public async Task<FiveDayThreeHourForecast> GetWeatherForecastsAsync(string cityName, string stateCode, string countryCode, int numberOfTimestamps, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters($"{cityName},{stateCode},{countryCode}", unit, numberOfTimestamps, lang);
            var payload = new OWPayload();
            payload.SetParameters(forecastEndpoint, parameters);

            return await forecastService.ProcessRequestAsync(payload);
        }

        public async Task<FiveDayThreeHourForecast> GetWeatherForecastAsync(long cityId, int numberOfTimestamps = 16, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters(cityId, unit, numberOfTimestamps, lang);
            var payload = new OWPayload();
            payload.SetParameters(forecastEndpoint, parameters);

            return await forecastService.ProcessRequestAsync(payload);
        }

        public async Task<FiveDayThreeHourForecast> GetWeatherForecastAsync(Coordinate coordinate, int numberOfTimestamps = 16, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters(coordinate, unit, numberOfTimestamps, lang);
            var payload = new OWPayload();
            payload.SetParameters(forecastEndpoint, parameters);

            return await forecastService.ProcessRequestAsync(payload);
        }

        public async Task<FiveDayThreeHourForecast> GetWeatherForecastAsync(long zipCode, string countryCode, int numberOfTimestamps = 16, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters(zipCode, countryCode, unit, numberOfTimestamps, lang);
            var payload = new OWPayload();
            payload.SetParameters(forecastEndpoint, parameters);

            return await forecastService.ProcessRequestAsync(payload);
        }

        private IEnumerable<Parameter> PrepareParameters(string searchTerm, Unit unit, int cnt, string lang)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) throw new ArgumentNullException("SearchTermRequired");

            if (cnt < 1 || cnt > 16) throw new ArgumentOutOfRangeException(nameof(cnt));

            return new[]
            {
                new Parameter { Name = "q", Value = searchTerm },
                new Parameter { Name = "units", Value = unit.ToDescription() },
                new Parameter { Name = "cnt", Value = cnt },
                new Parameter { Name = "lang", Value = lang }
            };
        }

        private IEnumerable<Parameter> PrepareParameters(long cityId, Unit unit, int cnt, string lang)
        {
            if (cnt < 1 || cnt > 16) throw new ArgumentOutOfRangeException(nameof(cnt));

            return new[]
            {
                new Parameter { Name = "id", Value = cityId.ToString() },
                new Parameter { Name = "units", Value = unit.ToDescription() },
                new Parameter { Name = "cnt", Value = cnt },
                new Parameter { Name = "lang", Value = lang }
            };
        }

        private IEnumerable<Parameter> PrepareParameters(Coordinate coordinate, Unit unit, int cnt, string lang)
        {
            if (coordinate == null || (coordinate.Lattitude == 0 && coordinate.Longitude == 0)) throw new ArgumentNullException("CoordincateRequired");

            if (cnt < 1 || cnt > 16) throw new ArgumentOutOfRangeException(nameof(cnt));

            return new[]
            {
                new Parameter { Name = "lat", Value = coordinate.Lattitude },
                new Parameter { Name = "lon", Value = coordinate.Longitude },
                new Parameter { Name = "units", Value = unit.ToDescription() },
                new Parameter { Name = "cnt", Value = cnt },
                new Parameter { Name = "lang", Value = lang }
            };
        }

        private IEnumerable<Parameter> PrepareParameters(long zipCode, string countryCode, Unit unit, int cnt, string lang)
        {
            if (zipCode == 0 || string.IsNullOrWhiteSpace(countryCode)) throw new ArgumentNullException("RequiredParameterMissing");

            if (cnt < 1 || cnt > 16) throw new ArgumentOutOfRangeException(nameof(cnt));

            return new[]
            {
                new Parameter { Name = "zip", Value = $"{zipCode},{countryCode}" },
                new Parameter { Name = "units", Value = unit.ToDescription() },
                new Parameter { Name = "cnt", Value = cnt },
                new Parameter { Name = "lang", Value = lang }
            };
        }
    }
}
