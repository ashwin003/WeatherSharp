using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;

namespace WeatherSharp.Shared.ServiceInterfaces
{
    public interface ICurrentWeatherService
    {
        Task<CurrentWeather> GetCurrentWeatherAsync(Coordinate coordinate, Unit unit = Unit.Standard, string lang = "en");

        Task<CurrentWeather> GetCurrentWeatherAsync(long cityId, Unit unit = Unit.Standard, string lang = "en");

        Task<CurrentWeather> GetCurrentWeatherAsync(long zipCode, string countryCode, Unit unit = Unit.Standard, string lang = "en");

        Task<CurrentWeather> GetCurrentWeatherAsync(string cityName, Unit unit = Unit.Standard, string lang = "en");

        Task<CurrentWeather> GetCurrentWeatherAsync(string cityName, string stateCode, string countryCode, Unit unit = Unit.Standard, string lang = "en");
    }
}