using System.Threading.Tasks;
using WeatherSharp.Client.Helpers;

namespace WeatherSharp.Client.ServiceInterfaces
{
    public interface IHttpService
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
    }
}