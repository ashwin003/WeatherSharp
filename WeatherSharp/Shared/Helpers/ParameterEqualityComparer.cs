using System.Collections.Generic;
using WeatherSharp.Shared.Entities.Request;

namespace WeatherSharp.Shared.Helpers
{
    public class ParameterEqualityComparer : IEqualityComparer<Parameter>
    {
        public bool Equals(Parameter x, Parameter y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;

            return x.Name == y.Name;
        }

        public int GetHashCode(Parameter obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
