using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.Entities.Response;

namespace WeatherSharp.Shared.ServiceInterfaces
{
    public interface IOneCallService
    {
        Task<OneCallResponse> GetOneCallResponseAsync(Coordinate coordinate, Unit unit = Unit.Standard, string lang = "en");
    }
}
