using Microsoft.AspNetCore.Components;

using System.Threading.Tasks;

namespace OnlineStoresManager.Web.App.Shared
{
    public partial class ThemeSelector : OnlineStoresManagerAwaitableComponent
    {
        private const string DarkTheme = "dark";
        private const string LightTheme = "light";

        [Inject]
        public LocalStorage LocalStorage { get; set; } = null!;

        protected bool IsDarkTheme => Theme == DarkTheme;
        protected string Theme { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Theme = await LocalStorage.GetTheme() ?? LightTheme;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await ImportJsFile("./Shared/ThemeSelector.razor.js");
                await InvokeJsMethod("setTheme", Theme);
            }
        }

        protected Task ToggleTheme()
        {
            return Await(async () =>
            {
                Theme = IsDarkTheme ? LightTheme : DarkTheme;
                await InvokeJsMethod("setTheme", Theme);
                await LocalStorage.SetTheme(Theme);
            });
        }
    }
}
