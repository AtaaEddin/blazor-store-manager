using Microsoft.AspNetCore.Components;

namespace HyOPT.Web.App
{
    public static class NavigationManagerExtensions
    {
        public static void NavigateToLogin(this NavigationManager navigator)
        {
            string returnUrl = navigator.ToBaseRelativePath(navigator.Uri);
            navigator.NavigateTo(string.IsNullOrEmpty(returnUrl) ? "/login" : $"/login?returnUrl={returnUrl}", true);
        }

        public static void NavigateToMarketList(this NavigationManager navigator)
        {
            navigator.NavigateTo("/markets");
        }

        public static void NavigateToScenarioList(this NavigationManager navigator)
        {
            navigator.NavigateTo("/scenarios");
        }
    }
}
