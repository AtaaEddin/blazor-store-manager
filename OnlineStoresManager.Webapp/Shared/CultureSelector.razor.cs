using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace OnlineStoresManager.Web.App.Shared
{
    public partial class CultureSelector : OnlineStoresManagerComponent
    {
        protected IDictionary<string, string> SupportedCultures = new Dictionary<string, string>
        {
            ["en-US"] = "English",
            ["de-DE"] = "German"
        };

        [Inject]
        public LocalStorage LocalStorage { get; set; } = null!;

        protected string? CurrentCultureName { get; set; }

        protected override void OnInitialized()
        {
            CurrentCultureName = CultureInfo.CurrentCulture.Name;
            base.OnInitialized();
        }

        protected async Task OnChanged(string? cultureName)
        {
            await LocalStorage.SetCulture(cultureName!);
            Navigator.NavigateTo(Navigator.Uri, true);
        }
    }
}
