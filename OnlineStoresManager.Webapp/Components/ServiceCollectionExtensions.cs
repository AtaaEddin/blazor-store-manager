using Microsoft.Extensions.DependencyInjection;
using OnlineStoresManager.WebApp.Components.Dialog;

namespace OnlineStoresManager.WebApp.Components
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOSMComponents(this IServiceCollection services)
        {
            return services.AddScoped<OSMDialogService>();
        }
    }
}
