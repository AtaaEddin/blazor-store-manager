using Microsoft.AspNetCore.Components;

using System.Threading.Tasks;

namespace OnlineStoresManager.Web.App.Pages.Identity
{
    public partial class LoginInfo : OnlineStoresManagerComponent
    {
        [Inject]
        public IdentityManager Manager { get; set; } = null!;

        protected Task Logout()
        {
            return Manager.Logout();
        }
    }
}
