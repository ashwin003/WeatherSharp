using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherSharp.Shared.Entities.Request;

namespace WeatherSharp.Shared.ServiceInterfaces
{
    /// <summary>
    /// Handles calls to a third party API and returns the results.
    /// </summary>
    /// <typeparam name="T">Type to which the results are to be deserialized.</typeparam>
    public interface IApiService<T> where T : class
    {
        /// <summary>
        /// Processes the request encapsulated within the <see cref="Payload"/> object and returns a list of results
        /// </summary>
        /// <param name="requestPayload"><see cref="Payload"/> object encapsulating all details for processing the request</param>
        /// <returns>A list of objects containing results of the request</returns>
        Task<IEnumerable<T>> ProcessListRequestAsync(Payload requestPayload);

        /// <summary>
        /// Processes the request encapsulated within the <see cref="Payload"/> object and returns a single result
        /// </summary>
        /// <param name="requestPayload"><see cref="Payload"/> object encapsulating all details for processing the request</param>
        /// <returns>A single object containing results of the request</returns>
        Task<T> ProcessRequestAsync(Payload requestPayload);
    }
}
