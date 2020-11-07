using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;

namespace WeatherSharp.Shared.ServiceInterfaces
{
    public interface IDailyForecastService
    {
        Task<DailyForecast> GetWeatherForecastAsync(string cityName, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en");

        Task<DailyForecast> GetWeatherForecastAsync(string cityName, string stateCode, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en");

        Task<DailyForecast> GetWeatherForecastAsync(string cityName, string stateCode, string countryCode, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en");

        Task<DailyForecast> GetWeatherForecastAsync(long cityId, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en");

        Task<DailyForecast> GetWeatherForecastAsync(Entities.Response.Coordinate coordinate, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en");

        Task<DailyForecast> GetWeatherForecastAsync(long zipCode, string countryCode, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en");
    }
}
