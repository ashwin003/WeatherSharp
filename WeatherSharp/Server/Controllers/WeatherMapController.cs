using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeatherSharp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherMapController : ControllerBase
    {
        private readonly ILogger<WeatherMapController> logger;

        public WeatherMapController(ILogger<WeatherMapController> logger)
        {
            this.logger = logger;
        }
    }
}
