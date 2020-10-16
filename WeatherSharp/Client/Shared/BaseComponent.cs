using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WeatherSharp.Client.Extensions;

namespace WeatherSharp.Client.Shared
{
    public class BaseComponent : ComponentBase
    {
        [Inject] private IJSRuntime js { get; set; }

        protected string Title { get; set; }

        protected void UpdateDocumentTitle(string title)
        {
            js.SetDocumentTitle(title);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if(firstRender)
            {
                UpdateDocumentTitle(Title);
            }
        }
    }
}
