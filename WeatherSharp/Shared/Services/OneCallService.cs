using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.Extensions;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Shared.Services
{
    public class OneCallService : IOneCallService
    {
        private readonly string oneCallEndpoint = "onecall";
        private readonly IApiService<OneCallResponse> oneCallService;

        public OneCallService(IApiService<OneCallResponse> oneCallService)
        {
            this.oneCallService = oneCallService;
        }

        public async Task<OneCallResponse> GetOneCallResponseAsync(Coordinate coordinate, Unit unit = Unit.Standard, string lang = "en")
        {
            var parameters = PrepareParameters(coordinate, unit, lang);
            var payload = new OWPayload();
            payload.SetParameters(oneCallEndpoint, parameters);

            return await oneCallService.ProcessRequestAsync(payload);
        }

        private IEnumerable<Parameter> PrepareParameters(Coordinate coordinate, Unit unit, string lang)
        {
            if (coordinate == null || (coordinate.Lattitude == 0 && coordinate.Longitude == 0)) throw new ArgumentNullException("CoordincateRequired");

            return new[]
            {
                new Parameter { Name = "lat", Value = coordinate.Lattitude },
                new Parameter { Name = "lon", Value = coordinate.Longitude },
                new Parameter { Name = "units", Value = unit.ToDescription() },
                new Parameter { Name = "lang", Value = lang }
            };
        }
    }
}
