using OnlineStoresManager.WebApp;

namespace OnlineStoresManager.WebApp.Shared
{
    public partial class NavMenu : OSMComponent
    {
        private bool _collapseNavMenu = true;
        protected string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }
    }
}
