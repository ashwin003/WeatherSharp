using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Server.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class CitySearcherController : ControllerBase
    {
        private readonly ICitySearcherService service;

        public CitySearcherController(ICitySearcherService service)
        {
            this.service = service;
        }
        public async Task<ActionResult<CityAutocompleteResponse>> Index(string searchTerm)
        {
            return Ok(await service.GetCitiesAsync(searchTerm));
        }
    }
}
