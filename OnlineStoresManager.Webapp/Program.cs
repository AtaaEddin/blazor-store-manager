using Blazored.LocalStorage;

using OnlineStoresManager.Web.App;
using OnlineStoresManager.Web.App.Components;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OnlineStoresManager.WebApp;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLocalization();
builder.Services.AddAuthorizationCore();
builder.Services.AddTelerikBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOnlineStoresManagerComponents();
builder.Services.AddOnlineStoresManagerCore(
    environment: builder.HostEnvironment,
    energyParkConfiguration: builder.Configuration.Bind<EnergyParkConfiguration>("EnergyParks"),
    marketConfiguration: builder.Configuration.Bind<MarketConfiguration>("Markets"),
    meteringConfiguration: builder.Configuration.Bind<MeteringConfiguration>("Metering"));

WebAssemblyHost app = builder.Build();
await app.SetDefaultCulture();
await app.RunAsync();
