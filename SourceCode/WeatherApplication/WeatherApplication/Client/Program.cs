using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeatherApplication.Client;
using WeatherApplication.Shared.Client.interfaces;
using WeatherApplication.Shared.Client.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("WeatherApplication.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WeatherApplication.ServerAPI"));
builder.Services.AddScoped<IShowWeatherDataViewModel, ShowWeatherDataViewModel>();
builder.Services.AddScoped<IndexViewModel>();
builder.Services.AddApiAuthorization();
builder.Services.AddLogging();

await builder.Build().RunAsync();
