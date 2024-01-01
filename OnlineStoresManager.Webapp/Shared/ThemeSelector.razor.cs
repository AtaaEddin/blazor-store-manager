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
        protected bool IsDarkMode { set; get; }
        protected MudThemeProvider? MudThemeProvider { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Theme.ZIndex.Dialog = 1200;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                var storedTheme = await LocalStorage.GetTheme();
                IsDarkMode = storedTheme != null && storedTheme!.Value;
                if(storedTheme == null)
                {
                    IsDarkMode = await MudThemeProvider!.GetSystemPreference();
                    await MudThemeProvider.WatchSystemPreference(OnSystemPreferenceChanged);
                    await LocalStorage.SetTheme(IsDarkMode);
                }

                StateHasChanged();
            }
        }
        private async Task OnSystemPreferenceChanged(bool newValue)
        {
            IsDarkMode = newValue;
            StateHasChanged();
        }

        protected Task ThemeChanged(bool value)
        {
            IsDarkMode = value;
            return Await(async () =>
            {
                await LocalStorage.SetTheme(IsDarkMode);
            });
        }
    }
}
