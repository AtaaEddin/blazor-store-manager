using OnlineStoresManager.WebApp;

namespace HyOPT.Web.App.Shared
{
    public partial class NavMenu : HyOPTComponent
    {
        private bool _collapseNavMenu = true;
        protected string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }
    }
}
