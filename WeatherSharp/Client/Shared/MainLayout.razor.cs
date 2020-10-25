using WeatherSharp.Client.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherSharp.Client.Models;
using WeatherSharp.Shared.Entities.Request;
using System.Linq;

namespace WeatherSharp.Client.Shared
{
    public partial class MainLayout
    {
        Unit unit = Unit.Standard;
        IEnumerable<SelectionItem> availableTemperatureScales = WeatherSharp.Shared.Helpers.TempaeratureScaleHelper.GetAvailableTemperatureScales().Select(option => new SelectionItem(option.DisplayName, option.ShortName, option.Unit));

        protected override async Task OnInitializedAsync()
        {
            if (await localStorageService.ContainKeyAsync(Constants.LocalStorage.TemperatureScale))
            {
                var unitFromLocalStorage = await localStorageService.GetItemAsync<int>(Constants.LocalStorage.TemperatureScale);
                unit = (Unit)unitFromLocalStorage;
            }
            await base.OnInitializedAsync();
        }

        async void onSelected(Unit selectedTemperatureScale)
        {
            await localStorageService.ReplaceItemAsync(Constants.LocalStorage.TemperatureScale, selectedTemperatureScale);
            js.ReloadPage();
        }

    }
}