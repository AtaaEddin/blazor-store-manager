namespace OnlineStoresManager.WebApp.Pages
{
    public partial class Index
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Navigator.NavigateToScenarioList();
        }
    }
}
