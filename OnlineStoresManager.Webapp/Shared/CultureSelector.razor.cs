using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        private const string DefaultCultureName = "English";
        protected override void OnInitialized()
        {
            if (SupportedCultures.TryGetValue(CultureInfo.CurrentCulture.Name, out string? cultureName))
            {
                CurrentCultureName = cultureName ?? DefaultCultureName;
            }
            else
            {
                CurrentCultureName = DefaultCultureName;
            }
            base.OnInitialized();
        }
        // TODO check if this will get invoked
        protected async Task OnChanged(string? cultureName)
        {
            KeyValuePair<string, string>? cultureSymbolPair = SupportedCultures.FirstOrDefault(pair => pair.Value == cultureName);
            if(string.IsNullOrEmpty(cultureSymbolPair?.Key))
            {
                await LocalStorage.SetCulture(cultureSymbolPair?.Key!);
                Navigator.NavigateTo(Navigator.Uri, true);
            }
        }
    }
}
