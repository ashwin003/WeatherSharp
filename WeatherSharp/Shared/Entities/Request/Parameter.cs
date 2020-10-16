namespace WeatherSharp.Shared.Entities.Request
{
    /// <summary>
    /// Holds parameter values to be passed to the API call
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Parameter Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the parameter
        /// </summary>
        public object Value { get; set; }
    }
}