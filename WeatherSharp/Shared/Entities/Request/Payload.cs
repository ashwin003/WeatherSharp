using System;
using System.Collections.Generic;
using System.Text;
using WeatherSharp.Shared.Helpers;

namespace WeatherSharp.Shared.Entities.Request
{
    public abstract class Payload
    {
        public string BaseUri { get; protected set; }

        public string ResourceUri { get; protected set; }

        public string UserAgent { get; protected set; } = string.Empty;

        public HashSet<Parameter> Parameters { get; private set; } = new HashSet<Parameter>(new ParameterEqualityComparer());

        public HashSet<Parameter> Headers { get; protected set; } = new HashSet<Parameter>(new ParameterEqualityComparer());

        public void SetParameters(string resourceUri, IEnumerable<Parameter> parameters)
        {
            ResourceUri = resourceUri;

            foreach (var parameter in parameters)
            {
                Parameters.Add(parameter);
            }
        }
    }
}
