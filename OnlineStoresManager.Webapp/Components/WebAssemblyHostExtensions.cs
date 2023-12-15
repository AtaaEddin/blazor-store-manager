using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System.Globalization;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp
{
    public static class WebAssemblyHostExtensions
    {
        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            LocalStorage localStorage = host.Services.GetRequiredService<LocalStorage>();
            string? cultureName = await localStorage.GetCulture();

            CultureInfo culture = !string.IsNullOrWhiteSpace(cultureName)
                ? new CultureInfo(cultureName)
                : new CultureInfo("en-US");

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
