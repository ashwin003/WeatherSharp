using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Response;

namespace WeatherSharp.Shared.ServiceInterfaces
{
    public interface ICitySearcherService
    {
        Task<CityAutocompleteResponse> GetCitiesAsync(string searchTerm);
    }
}