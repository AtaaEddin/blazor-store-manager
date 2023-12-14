using OnlineStoresManager.Abstractions;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OnlineStoresManager.Web.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOnlineStoresManagerCore(
            this IServiceCollection services,
            IWebAssemblyHostEnvironment environment)
        {
            services
                .AddJsonOptions()
                .AddOnlineStoresManagerAssets(environment)
                .AddOnlineStoresManagerIdentity(environment);

            services.AddScoped<LocalStorage>();

            return services;
        }

        private static IServiceCollection AddOnlineStoresManagerAssets(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
        {
            services
                .AddScoped<AssetValidator>()
                .AddScoped<AssetValidatorBuilder>()
                .AddScoped<BatteryStorageAssetValidator>()
                .AddScoped<ChargePointAssetValidator>()
                .AddScoped<ChargePointValidator>()
                .AddScoped<ConsumptionAssetValidator>()
                .AddScoped<ElektrolysisPlantAssetValidator>()
                .AddScoped<HydrogenStorageAssetValidator>()
                .AddScoped<WindturbineAssetValidator>();

            services
                .AddHttpClient<AssetService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/assets/"))
                .AddHttpMessageHandler<ServiceClientAuthenticator>();

            return services;
        }

        private static IServiceCollection AddOnlineStoresManagerIdentity(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
        {
            services
                .AddScoped<AuthenticationStateProvider, IdentityStateProvider>()
                .AddScoped<IdentityManager>()
                .AddScoped<LoginRequestValidator>()
                .AddScoped<ServiceClientAuthenticator>();

            services.AddHttpClient<IdentityService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/identity/"));

            return services;
        }

        private static IServiceCollection AddJsonOptions(this IServiceCollection services)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.AddExpressionConverters();
            options.AddPagedListConverters();

            services.AddSingleton(options);

            return services;
        }
    }
}
