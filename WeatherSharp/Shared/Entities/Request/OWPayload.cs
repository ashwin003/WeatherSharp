namespace WeatherSharp.Shared.Entities.Request
{
    public class OWPayload : Payload
    {
        private readonly Parameter appIdParameter;

        public OWPayload()
        {
            BaseUri = "https://api.openweathermap.org/data/2.5/";

            appIdParameter = new Parameter { Name = "appid", Value = "dbc1e5730c8e16b57d7a7535d4c9508e" };
            Parameters.Add(appIdParameter);
        }
    }
}
