using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OneCallController : ControllerBase
    {
        private readonly ILogger<OneCallController> logger;
        private readonly IOneCallService oneCallService;

        public OneCallController(ILogger<OneCallController> logger, IOneCallService oneCallService)
        {
            this.logger = logger;
            this.oneCallService = oneCallService;
        }
    }
}
