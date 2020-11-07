using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FiveDayThreeHourForecastController : ControllerBase
    {
        private readonly ILogger<FiveDayThreeHourForecastController> logger;
        private readonly IFiveDayThreeHourForecastService forecastService;

        public FiveDayThreeHourForecastController(ILogger<FiveDayThreeHourForecastController> logger, IFiveDayThreeHourForecastService forecastService)
        {
            this.logger = logger;
            this.forecastService = forecastService;
        }
    }
}
