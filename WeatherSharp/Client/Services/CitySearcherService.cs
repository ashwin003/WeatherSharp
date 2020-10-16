using System.Threading.Tasks;
using WeatherSharp.Client.ServiceInterfaces;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Client.Services
{
    public class CitySearcherService : ICitySearcherService
    {
        private readonly IHttpService service;

        public CitySearcherService(IHttpService service)
        {
            this.service = service;
        }
        public async Task<CityAutocompleteResponse> GetCitiesAsync(string searchTerm)
        {
            var httpResponse = await service.Get<CityAutocompleteResponse>($"CitySearcher?searchTerm={searchTerm}");
            return httpResponse.Response;
        }
    }
}
