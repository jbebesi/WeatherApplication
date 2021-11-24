using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Client.HttpClients;
using WeatherApplication.Client.ViewModels;

namespace WeatherApplication.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(sp => new SubscriptionHttpClient { BaseAddress = new Uri("http://subscriptionservice:81") });
            builder.Services.AddScoped<ShowWeatherDataViewModel>();
            builder.Services.AddLogging();

            await builder.Build().RunAsync();
        }
    }
}
