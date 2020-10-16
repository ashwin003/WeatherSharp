using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherSharp.Client.Extensions;
using WeatherSharp.Client.Models;
using WeatherSharp.Shared.Entities.Response;
using WeatherSharp.Shared.ServiceInterfaces;

namespace WeatherSharp.Client.Pages
{
    public partial class Favorites
    {
        public Favorites()
        {
            Title = "Favorites";
        }

        private City _city;
        City SelectedCity
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
                HandleSelection(_city);
            }
        }

        private async Task<IEnumerable<City>> SearchLocations(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length < 3)
                return await Task.FromResult(Enumerable.Empty<City>());
            var citySearchResults = await citySearcherService.GetCitiesAsync(searchTerm);
            return citySearchResults.Cities;
        }

        private async Task HandleSelection(City city)
        {
            await localStorageService.ReplaceItemAsync(Constants.LocalStorage.City, city);

            navigationManager.NavigateTo("");
        }

        [Inject] private ILocalStorageService localStorageService { get; set; }
        [Inject] private ICitySearcherService citySearcherService { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
    }
}