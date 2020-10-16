using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherSharp.Shared;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> logger;
        private readonly ICurrentWeatherService weatherService;

        public WeatherController(ILogger<WeatherController> logger, ICurrentWeatherService weatherService)
        {
            this.logger = logger;
            this.weatherService = weatherService;
        }

        [HttpGet]
        public async Task<CurrentWeather> GetCurrentWeather(string city, string state, string country)
        {
            if(string.IsNullOrWhiteSpace(state) && string.IsNullOrWhiteSpace(country))
            {
                return await weatherService.GetCurrentWeatherAsync(city);
            }

            return await weatherService.GetCurrentWeatherAsync(city, state, country);
        }
    }
}
