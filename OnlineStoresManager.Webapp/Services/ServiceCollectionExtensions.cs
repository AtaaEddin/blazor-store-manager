using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using MudBlazor.Services;

using OnlineStoresManager.Abstractions;
using OnlineStoresManager.WebApp.Services.Goods;
using OnlineStoresManager.WebApp.Services;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OnlineStoresManager.WebApp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMudBlazor(
            this IServiceCollection services)
        {
            services
                .AddMudServices();

            return services;
        }

        public static IServiceCollection AddOnlineStoresManagerCore(
            this IServiceCollection services,
            IWebAssemblyHostEnvironment environment)
        {
            services
                .AddJsonOptions()
                .AddOnlineStoresManagerGoods(environment)
                .AddOnlineStoresManagerIdentity(environment)
                .AddOnlineStoresManagerImageUpload(environment);

            services.AddScoped<LocalStorage>();

            return services;
        }

        private static IServiceCollection  AddOnlineStoresManagerImageUpload(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
        {
            services
                .AddHttpClient<ImageService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/image/"))
                .AddHttpMessageHandler<ServiceClientAuthenticator>();

            return services;
        }

        private static IServiceCollection AddOnlineStoresManagerGoods(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
        {
            services
                .AddScoped<ShortStoryValidation>()
                .AddScoped<GoodValidation>()
                .AddScoped<GoodValidationBuilder>()
                .AddScoped<ShirtValidation>();

            services
                .AddHttpClient<GoodService>(client => client.BaseAddress = new Uri($"{environment.BaseAddress}api/goods/"))
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
