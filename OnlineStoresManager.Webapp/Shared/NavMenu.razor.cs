using OnlineStoresManager.WebApp;

namespace OnlineStoresManager.Web.App.Shared
{
    public partial class NavMenu : OnlineStoresManagerComponent
    {
        private bool _collapseNavMenu = true;
        protected string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }
    }
}
