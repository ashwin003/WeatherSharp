using Blazored.LocalStorage;
using System.Threading.Tasks;

namespace WeatherSharp.Client.Extensions
{
    internal static class LocalStorageExtensions
    {
        internal static async Task ReplaceItemAsync<T>(this ILocalStorageService localStorageService, string key, T value)
        {
            if(await localStorageService.ContainKeyAsync(key))
            {
                await localStorageService.RemoveItemAsync(key);
            }

            await localStorageService.SetItemAsync(key, value);
        }
    }
}
