using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using WeatherApplication.Shared.Dtos.OWM;
using WeatherApplication.Shared.Interfaces;
using WeatherApplication.Shared.Services;
using WeatherApplication.Shared.Services.OWM;

namespace WeatherApplication.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IWeatherDataStore, WeatherDataStore>();
            services.AddScoped<IWeatherProvider, ConnectOpenWeatherMap>(provider => new ConnectOpenWeatherMap(
                provider.GetService<HttpClient>(),
                provider.GetService<ILogger<ConnectOpenWeatherMap>>(), new OWMSettings()
                {
                    APIKey = Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.APIKey)}").Value,
                    OneCallAPI = Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.OneCallAPI)}").Value,
                    ForecastUrl = Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.ForecastUrl)}").Value,
                    CityPref = Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.CityPref)}").Value,
                    Metric = Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.Metric)}").Value,
                    Lat = Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.Lat)}").Value,
                    Lon = Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.Lon)}").Value
                }));
            services.AddScoped<ICityListProvider, CityListProvider>();
            services.AddScoped<HttpClient>();
            services.AddRazorPages();

            services.AddApplicationInsightsTelemetry(Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
