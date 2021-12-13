using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeatherApplication.Shared.Client.interfaces;
using WeatherApplication.Shared.Client.ViewModels;

namespace WeatherApplication.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IShowWeatherDataViewModel, ShowWeatherDataViewModel>();
            builder.Services.AddScoped<IndexViewModel>();
            builder.Services.AddLogging();

            await builder.Build().RunAsync();
        }
    }
}
