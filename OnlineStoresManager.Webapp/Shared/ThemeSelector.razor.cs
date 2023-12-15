using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Shared
{
    public partial class ThemeSelector : OSMAwaitableComponent
    {
        [Inject]
        public LocalStorage LocalStorage { get; set; } = null!;

        protected MudTheme Theme = new();
        protected bool IsDarkMode;
        protected MudThemeProvider? MudThemeProvider { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            IsDarkMode = await LocalStorage.GetTheme() ?? false;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                IsDarkMode = await MudThemeProvider!.GetSystemPreference();
                await MudThemeProvider.WatchSystemPreference(OnSystemPreferenceChanged);
                await ImportJsFile("./Shared/ThemeSelector.razor.js");
                await InvokeJsMethod("setTheme", Theme);
                StateHasChanged();
            }
        }
        private async Task OnSystemPreferenceChanged(bool newValue)
        {
            IsDarkMode = newValue;
            StateHasChanged();
        }

        protected Task IsDarkModeChanged(bool value)
        {
            IsDarkMode = value;
            return Await(async () =>
            {
                await InvokeJsMethod("setTheme", Theme);
                await LocalStorage.SetTheme(IsDarkMode);
            });
        }
    }
}
