namespace OnlineStoresManager.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHyOPTCore(
            this IServiceCollection services,
            IdentityConfiguration identityConfiguration,
            ScenarioConfiguration scenarioConfiguration)
        {
            return services
                .AddHyOPTAssets()
                .AddHyOPTCommon()
                .AddHyOPTEnergyParks()
                .AddHyOPTIdentity(identityConfiguration)
                .AddHyOPTMarkets()
                .AddHyOPTMastr()
                .AddHyOPTMeterings()
                .AddHyOPTScenarios(scenarioConfiguration)
                .AddHyOPTTransmissions();
        }

        private static IServiceCollection AddHyOPTAssets(this IServiceCollection services)
        {
            return services
                .AddScoped<AssetStore>()
                .AddScoped<IAssetManager, AssetManager>()
                .AddScoped<ChargePointStore>();
        }

        private static IServiceCollection AddHyOPTCommon(this IServiceCollection services)
        {
            return services
                .AddScoped<FileExporter>();
        }

        private static IServiceCollection AddHyOPTEnergyParks(this IServiceCollection services)
        {
            return services
                .AddScoped<EnergyParkStore>()
                .AddScoped<IEnergyParkManager, EnergyParkManager>();
        }

        private static IServiceCollection AddHyOPTIdentity(this IServiceCollection services, IdentityConfiguration identityConfiguration)
        {
            return services
                .AddSingleton<IdentityConfiguration>(identityConfiguration)
                .AddScoped<IdentityService>();
        }

        private static IServiceCollection AddHyOPTMarkets(this IServiceCollection services)
        {
            return services
                .AddScoped<IMarketManager, MarketManager>()
                .AddScoped<MarketStore>()
                .AddScoped<PartnerDGOStore>()
                .AddScoped<PartnerOperatorStore>()
                .AddScoped<PartnerTSOStore>()
                .AddScoped<ProductStore>();
        }

        private static IServiceCollection AddHyOPTMastr(this IServiceCollection services)
        {
            return services
                .AddScoped<MastrAssetStore>()
                .AddScoped<IMastrManager, MastrManager>();
        }

        private static IServiceCollection AddHyOPTMeterings(this IServiceCollection services)
        {
            return services
                .AddScoped<MeteringPointStore>()
                .AddScoped<IMeteringManager, MeteringManager>();
        }

        private static IServiceCollection AddHyOPTScenarios(this IServiceCollection services, ScenarioConfiguration configuration)
        {
            return services
                .AddScoped<AssetScenarioStore>()
                .AddScoped<IScenarioManager, ScenarioManager>()
                .AddScoped<MarketScenarioStore>()
                .AddScoped<OptimizationRunStore>()
                .AddScoped<OptimizationRunLogStore>()
                .AddSingleton<ScenarioConfiguration>(configuration)
                .AddScoped<ScenarioStore>();
        }

        private static IServiceCollection AddHyOPTTransmissions(this IServiceCollection services)
        {
            return services
                .AddScoped<TransmissionEfficiencyStore>()
                .AddScoped<TransmissionEligibilityStore>()
                .AddScoped<TransmissionLimitStore>()
                .AddScoped<ITransmissionManager, TransmissionManager>();
        }
    }
}
