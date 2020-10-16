using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherSharp.Client.ServiceInterfaces;
using WeatherSharp.Client.Services;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<ICitySearcherService, CitySearcherService>();
            services.AddScoped<ICurrentWeatherService, CurrentWeatherService>();
            services.AddBlazoredLocalStorage();
        }
    }
}
