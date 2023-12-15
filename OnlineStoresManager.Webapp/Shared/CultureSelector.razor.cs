using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Shared
{
    public partial class CultureSelector : OSMComponent
    {
        protected IDictionary<string, string> SupportedCultures = new Dictionary<string, string>
        {
            ["ar-AR"] = "Arabic",
            ["en-US"] = "English",
            ["de-DE"] = "German",
            ["tr-TR"] = "Turkish"
        };

        [Inject]
        public LocalStorage LocalStorage { get; set; } = null!;

        protected string? CurrentCultureName { get; set; }

        protected override void OnInitialized()
        {
            CurrentCultureName = CultureInfo.CurrentCulture.Name;
            base.OnInitialized();
        }
        // TODO check if this will get invoked
        protected async Task OnChanged(string? cultureName)
        {
            await LocalStorage.SetCulture(cultureName!);
            Navigator.NavigateTo(Navigator.Uri, true);
        }
    }
}
