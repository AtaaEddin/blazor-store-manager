using Microsoft.Extensions.DependencyInjection;
using OnlineStoresManager.WebApp.Components.Dialog;

namespace HyOPT.Web.App.Components
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHyOPTComponents(this IServiceCollection services)
        {
            return services.AddScoped<HyOPTDialogService>();
        }
    }
}
