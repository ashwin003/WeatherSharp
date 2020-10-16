using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeatherSharp.Shared.Entities.Request;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Shared.Services
{
    public class ApiService<T> : IApiService<T> where T : class
    {
        
        public async Task<IEnumerable<T>> ProcessListRequestAsync(Payload requestPayload)
        {
            var (request, client) = PrepareRequest(requestPayload);

            var taskCompletionSource = new TaskCompletionSource<IEnumerable<T>>();

            var response = await client.ExecuteAsync(request);
            if (IsFailure(response))
                throw response.ErrorException;

            taskCompletionSource.SetResult(JsonConvert.DeserializeObject<IEnumerable<T>>(ConvertToJson(response.Content)));

            return await taskCompletionSource.Task;
        }

        public async Task<T> ProcessRequestAsync(Payload requestPayload)
        {
            var (request, client) = PrepareRequest(requestPayload);

            var taskCompletionSource = new TaskCompletionSource<T>();

            var response = await client.ExecuteAsync(request);
            if (IsFailure(response))
                throw response.ErrorException;
            taskCompletionSource.SetResult(JsonConvert.DeserializeObject<T>(ConvertToJson(response.Content)));

            return await taskCompletionSource.Task;
        }

        /// <summary>
        /// Prepares the request object with the data from the supplied <see cref="Payload"/>
        /// </summary>
        /// <param name="requestPayload">Request payload containing all information required for initiating a REST call to any API</param>
        /// <returns><see cref="RestClient"/> and <see cref="RestRequest"/> objects containing the related information</returns>
        private (IRestRequest request, IRestClient client) PrepareRequest(Payload requestPayload)
        {
            var client = new RestClient(requestPayload.BaseUri);

            var request = new RestRequest(requestPayload.ResourceUri, Method.GET);

            foreach (var parameter in requestPayload.Parameters)
            {
                request.AddParameter(parameter.Name, parameter.Value);
            }

            foreach (var header in requestPayload.Headers)
            {
                request.AddHeader(header.Name, header.Value.ToString());
            }

            return (request, client);
        }

        private static string ConvertToJson(string response)
        {
            if (!IsXml(response))
                return response;

            var xmlElement = XElement.Parse(response);

            EliminateUnnecessaryXmlArtifacts(xmlElement);

            return JsonConvert.SerializeXNode(xmlElement, Formatting.None, true);
        }

        private static bool IsXml(string input) => input.TrimStart().StartsWith("<");

        private static bool IsFailure(IRestResponse response) => !response.IsSuccessful &&
                                                                  response.StatusCode != System.Net.HttpStatusCode.Accepted &&
                                                                  response.ErrorException != null;

        #region Xml Cleanup
        private static void EliminateUnnecessaryXmlArtifacts(XElement xmlElement)
        {
            EliminateXCData(xmlElement);
            EliminateUnnecessaryAttributes(xmlElement);

            EliminateWrappedArrays(xmlElement);
        }

        private static void EliminateXCData(XElement xmlElement)
        {
            foreach (var cd in xmlElement.DescendantNodes().OfType<XCData>().ToList())
            {
                cd.Parent.Add(cd.Value);
                cd.Remove();
            }
        }

        private static void EliminateUnnecessaryAttributes(XElement xmlElement)
        {
            var attributesToRemove = new[] { "type", "nil", "nophoto" };

            xmlElement.Descendants().SelectMany(x => attributesToRemove.SelectMany(y => x.Attributes(y))).Where(x => x != null).Remove();
        }

        private static void EliminateWrappedArrays(XElement xmlElement)
        {
            var wrappedElements = GetAllWrappedElements(xmlElement);
            while (wrappedElements.Any())
            {
                XNamespace nameSpace = "http://james.newtonking.com/projects/json";
                var childElements = wrappedElements.ElementAt(0).Elements();
                foreach (var child in childElements)
                    child.Add(new XAttribute(nameSpace + "Array", true));

                wrappedElements.ElementAt(0).Parent.Add(childElements);
                wrappedElements.ElementAt(0).Remove();
            }
        }

        private static IEnumerable<XElement> GetAllWrappedElements(XElement element)
        {
            return element.Elements().SelectMany(childElement =>
            {
                return IsWrapped(childElement) ? new[] { childElement } : GetAllWrappedElements(childElement);
            });
        }

        private static bool IsWrapped(XElement element)
        {
            // Element is leaf level element. Cannot be wrapped
            if (!element.HasElements)
                return false;
            // Wrapped array elements have a list of same tags inside of them
            return element.Elements().Select(x => x.Name).Distinct().Count() == 1;
        }
        #endregion
    }
}
