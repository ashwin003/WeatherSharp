using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace WeatherSharp.Client.Extensions
{
    public static class DomJsExtensions
    {
        public static void SetDocumentTitle(this IJSRuntime js, string title)
        {
            js.InvokeVoidAsync("updateDocumentTitle", title);
        }

        public static void ReloadPage(this IJSRuntime js) {
            js.InvokeVoidAsync("reload");
        }

        public static async Task<string> GetDocumentTitle(this IJSRuntime js)
        {
            return await js.InvokeAsync<string>("readDocumentTitle");
        }
    }
}
