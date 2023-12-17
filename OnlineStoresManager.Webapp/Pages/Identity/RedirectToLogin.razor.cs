namespace OnlineStoresManager.WebApp.Pages.Identity
{
    public partial class RedirectToLogin : OSMComponent
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Navigator.NavigateToLogin();
        }
    }
}
