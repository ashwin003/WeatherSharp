using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;

namespace WeatherSharp.Shared.ServiceInterfaces
{
    public interface IFiveDayThreeHourForecastService
    {
        Task<FiveDayThreeHourForecast> GetWeatherForecastAsync(long cityId, int numberOfTimestamps = 16, Unit unit = Unit.Standard, string lang = "en");

        Task<FiveDayThreeHourForecast> GetWeatherForecastAsync(Coordinate coordinate, int numberOfTimestamps = 16, Unit unit = Unit.Standard, string lang = "en");

        Task<FiveDayThreeHourForecast> GetWeatherForecastAsync(long zipCode, string countryCode, int numberofTimestamps = 16, Unit unit = Unit.Standard, string lang = "en");

        Task<FiveDayThreeHourForecast> GetWeatherForecastsAsync(string cityName, int numberOfTimestamps, Unit unit = Unit.Standard, string lang = "en");

        Task<FiveDayThreeHourForecast> GetWeatherForecastsAsync(string cityName, string stateCode, int numberOfTimestamps, Unit unit = Unit.Standard, string lang = "en");

        Task<FiveDayThreeHourForecast> GetWeatherForecastsAsync(string cityName, string stateCode, string countryCode, int numberOfTimestamps, Unit unit = Unit.Standard, string lang = "en");
    }
}
