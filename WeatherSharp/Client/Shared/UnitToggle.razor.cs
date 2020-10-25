using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherSharp.Client.Models;
using WeatherSharp.Shared.Entities.Request;

namespace WeatherSharp.Client.Shared
{
    public partial class UnitToggle
    {
        [Parameter]
        public IEnumerable<SelectionItem> AvailableOptions
        {
            get;
            set;
        }

        [Parameter]
        public Unit SelectedOption
        {
            get;
            set;
        }

        [Parameter]
        public EventCallback<Unit> OnSelected
        {
            get;
            set;
        }

        private string GetButtonClass(Unit selectedOption)
        {
            if(selectedOption == SelectedOption)
            {
                return "btn-info";
            }

            return "btn-default";
        }

        private async Task OnClick(Unit selectedOption)
        {
            SelectedOption = selectedOption;

            await OnSelected.InvokeAsync(selectedOption);
        }
    }
}