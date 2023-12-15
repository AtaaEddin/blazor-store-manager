using Microsoft.AspNetCore.Components;

using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Pages.Identity
{
    public partial class LoginInfo : OSMComponent
    {
        [Inject]
        public IdentityManager Manager { get; set; } = null!;

        protected Task Logout()
        {
            return Manager.Logout();
        }
    }
}
