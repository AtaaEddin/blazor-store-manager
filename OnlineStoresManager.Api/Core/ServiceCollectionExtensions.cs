using OnlineStoresManager.API.Core.images;
using OnlineStoresManager.API.Goods;

namespace OnlineStoresManager.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOnlineStoresManagerCore(
            this IServiceCollection services,
            IdentityConfiguration identityConfiguration,
            UploadImageConfiguration uploadImageConfiguration)
        {
            return services
                .OnlineStoresManagerGoods()
                .OnlineStoresManagerCommon()
                .OnlineStoresManagerIdentity(identityConfiguration)
                .OnlineStoresManagerImageUpload(uploadImageConfiguration);
        }

        private static IServiceCollection OnlineStoresManagerGoods(this IServiceCollection services)
        {
            return services
                .AddScoped<GoodStore>()
                .AddScoped<IGoodManager, GoodManager>();
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

        private static IServiceCollection OnlineStoresManagerImageUpload(this IServiceCollection services, UploadImageConfiguration uploadImageConfiguration)
        {
            return services
                .AddSingleton<UploadImageConfiguration>(uploadImageConfiguration)
                .AddScoped<ImageService>();
        }
    }
}
