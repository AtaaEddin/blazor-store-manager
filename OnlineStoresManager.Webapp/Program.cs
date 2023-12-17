using Blazored.LocalStorage;

using OnlineStoresManager.WebApp;
using OnlineStoresManager.WebApp.Components;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLocalization();
builder.Services.AddAuthorizationCore();
builder.Services.AddMudBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOSMComponents();
builder.Services.AddOnlineStoresManagerCore(
    environment: builder.HostEnvironment);

WebAssemblyHost app = builder.Build();
await app.SetDefaultCulture();
await app.RunAsync();
