using Microsoft.Extensions.DependencyInjection;
using OnlineStoresManager.WebApp.Components.Dialog;

namespace OnlineStoresManager.Web.App.Components
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOnlineStoresManagerComponents(this IServiceCollection services)
        {
            return services.AddScoped<OnlineStoresManagerDialogService>();
        }
    }
}
