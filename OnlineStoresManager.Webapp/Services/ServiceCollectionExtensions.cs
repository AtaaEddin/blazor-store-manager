using HyOPT.Abstractions;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HyOPT.Web.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHyOPTCore(
            this IServiceCollection services,
            IWebAssemblyHostEnvironment environment,
            EnergyParkConfiguration energyParkConfiguration,
            MarketConfiguration marketConfiguration,
            MeteringConfiguration meteringConfiguration)
        {
            services
                .AddJsonOptions()
                .AddHyOPTAssets(environment)
                .AddHyOPTEnergyParks(environment, energyParkConfiguration)
                .AddHyOPTIdentity(environment)
                .AddHyOPTMarkets(environment, marketConfiguration)
                .AddHyOPTMastr(environment)
                .AddHyOPTMeterings(environment, meteringConfiguration)
                .AddHyOPTScenarios(environment)
                .AddHyOPTTransmissions(environment);

            services.AddScoped<LocalStorage>();

            return services;
        }

        private static IServiceCollection AddHyOPTAssets(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
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

        private static IServiceCollection AddHyOPTEnergyParks(this IServiceCollection services, IWebAssemblyHostEnvironment environment, EnergyParkConfiguration configuration)
        {
            services
                .AddSingleton<EnergyParkConfiguration>(configuration)
                .AddScoped<EnergyParkUrlBuilder>()
                .AddScoped<EnergyParkValidator>();

            services
                .AddHttpClient<EnergyParkService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/energy-parks/"))
                .AddHttpMessageHandler<ServiceClientAuthenticator>();

            return services;
        }

        private static IServiceCollection AddHyOPTIdentity(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
        {
            services
                .AddScoped<AuthenticationStateProvider, IdentityStateProvider>()
                .AddScoped<IdentityManager>()
                .AddScoped<LoginRequestValidator>()
                .AddScoped<ServiceClientAuthenticator>();

            services.AddHttpClient<IdentityService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/identity/"));

            return services;
        }

        private static IServiceCollection AddHyOPTMarkets(this IServiceCollection services, IWebAssemblyHostEnvironment environment, MarketConfiguration configuration)
        {
            services
                .AddSingleton<MarketConfiguration>(configuration)
                .AddScoped<MarketUrlBuilder>()
                .AddScoped<MarketValidator>()
                .AddScoped<PartnerDGOValidator>()
                .AddScoped<PartnerOperatorValidator>()
                .AddScoped<PartnerTSOValidator>()
                .AddScoped<ProductValidator>();

            services
                .AddHttpClient<MarketService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/markets/"))
                .AddHttpMessageHandler<ServiceClientAuthenticator>();

            return services;
        }

        private static IServiceCollection AddHyOPTMastr(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
        {
            services.AddScoped<MastrAssetValidator>();

            services
                .AddHttpClient<MastrService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/mastr/"))
                .AddHttpMessageHandler<ServiceClientAuthenticator>();

            return services;
        }

        private static IServiceCollection AddHyOPTMeterings(this IServiceCollection services, IWebAssemblyHostEnvironment environment, MeteringConfiguration configuration)
        {
            services
                .AddSingleton<MeteringConfiguration>(configuration)
                .AddScoped<MeteringUrlBuilder>()
                .AddScoped<MeteringPointValidator>();

            services
                .AddHttpClient<MeteringService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/meterings/"))
                .AddHttpMessageHandler<ServiceClientAuthenticator>();

            return services;
        }

        private static IServiceCollection AddHyOPTScenarios(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
        {
            services
                .AddScoped<AssetScenarioValidator>()
                .AddScoped<ScenarioValidator>();

            services
                .AddHttpClient<ScenarioService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/scenarios/"))
                .AddHttpMessageHandler<ServiceClientAuthenticator>();

            return services;
        }

        private static IServiceCollection AddHyOPTTransmissions(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
        {
            services
                .AddScoped<TransmissionEfficiencyValidator>()
                .AddScoped<TransmissionEligibilityValidator>()
                .AddScoped<TransmissionLimitValidator>();

            services
                .AddHttpClient<TransmissionService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/transmissions/"))
                .AddHttpMessageHandler<ServiceClientAuthenticator>();

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
