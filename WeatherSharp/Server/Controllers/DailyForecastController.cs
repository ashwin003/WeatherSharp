using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WeatherSharp.Shared;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyForecastController : ControllerBase
    {
        private readonly ILogger<DailyForecastController> logger;
        private readonly IDailyForecastService dailyForecastService;

        public DailyForecastController(ILogger<DailyForecastController> logger, IDailyForecastService dailyForecastService)
        {
            this.logger = logger;
            this.dailyForecastService = dailyForecastService;
        }

        [HttpGet]
        public async Task<DailyForecast> GetDailyForecast(string city, string state, string country, int numberOfDays = 16, Unit unit = Unit.Standard, string lang = "en")
        {
            if (string.IsNullOrWhiteSpace(state) && string.IsNullOrWhiteSpace(country))
            {
                return await dailyForecastService.GetWeatherForecastAsync(city, numberOfDays, unit, lang);
            }

            return await dailyForecastService.GetWeatherForecastAsync(city, state, country, numberOfDays, unit, lang);
        }
    }
}
