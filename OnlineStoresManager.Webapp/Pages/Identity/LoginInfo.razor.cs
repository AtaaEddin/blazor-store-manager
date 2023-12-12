using Microsoft.AspNetCore.Components;

using System.Threading.Tasks;

namespace HyOPT.Web.App.Pages.Identity
{
    public partial class LoginInfo : HyOPTComponent
    {
        [Inject]
        public IdentityManager Manager { get; set; } = null!;

        protected Task Logout()
        {
            return Manager.Logout();
        }
    }
}
