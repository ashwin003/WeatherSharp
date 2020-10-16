using System;
using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Shared.Services
{
    public class CitySearcherService : ICitySearcherService
    {
        private readonly IApiService<CityAutocompleteResponse> cityService;
        public CitySearcherService(IApiService<CityAutocompleteResponse> cityService)
        {
            this.cityService = cityService;
        }

        public async Task<CityAutocompleteResponse> GetCitiesAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length < 3) throw new ArgumentOutOfRangeException("SearchTermLength3");

            var parameters = new[]
            {
                new Parameter { Name = "q", Value = searchTerm }
            };
            var payload = new PhotonPayload();
            payload.SetParameters("api", parameters);

            return await cityService.ProcessRequestAsync(payload);
        }
    }
}
