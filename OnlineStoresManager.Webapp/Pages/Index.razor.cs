namespace OnlineStoresManager.Web.App.Pages
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
