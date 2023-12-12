using OnlineStoresManager.API.Goods;

namespace OnlineStoresManager.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection OnlineStoresManagerCore(
            this IServiceCollection services,
            IdentityConfiguration identityConfiguration)
        {
            return services
                .OnlineStoresManagerGoods()
                .OnlineStoresManagerCommon()
                .OnlineStoresManagerIdentity(identityConfiguration)
        }

        private static IServiceCollection OnlineStoresManagerGoods(this IServiceCollection services)
        {
            return services
                .AddScoped<GoodStore>()
                .AddScoped<IAssetManager, AssetManager>()
        }

        private static IServiceCollection OnlineStoresManagerCommon(this IServiceCollection services)
        {
            return services
                .AddScoped<FileExporter>();
        }

        private static IServiceCollection OnlineStoresManagerIdentity(this IServiceCollection services, IdentityConfiguration identityConfiguration)
        {
            return services
                .AddSingleton<IdentityConfiguration>(identityConfiguration)
                .AddScoped<IdentityService>();
        }
    }
}
