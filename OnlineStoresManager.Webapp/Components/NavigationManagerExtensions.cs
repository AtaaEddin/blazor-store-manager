using Microsoft.AspNetCore.Components;

namespace OnlineStoresManager.WebApp
{
    public static class NavigationManagerExtensions
    {
        public static void NavigateToLogin(this NavigationManager navigator)
        {
            string returnUrl = navigator.ToBaseRelativePath(navigator.Uri);
            navigator.NavigateTo(string.IsNullOrEmpty(returnUrl) ? "/login" : $"/login?returnUrl={returnUrl}", true);
        }

        public static void NavigateToStoresHomePage(this NavigationManager navigator)
        {
            navigator.NavigateTo("/");
        }

        public static void NavigateToAdminHomePage(this NavigationManager navigator)
        {
            navigator.NavigateTo("/Admin");
        }
    }
}
