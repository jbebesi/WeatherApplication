using WeatherApplication.Server.interfaces;
using WeatherApplication.Server.Services;
using WeatherApplication.Shared.Dtos.OWM;
using WeatherApplication.Shared.Interfaces;
using WeatherApplication.Shared.Services;
using WeatherApplication.Shared.Services.OWM;

namespace WeatherApplication.Server
{
    public static class StartupExtensions
    {
        public static void WettaServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ISubscriptionHelper, SubscriptionHelper>();

            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IWeatherDataStore, WeatherDataStore>();
            builder.Services.AddScoped<IWeatherProvider, ConnectOpenWeatherMap>(provider => new ConnectOpenWeatherMap(
                provider.GetService<HttpClient>(),
                provider.GetService<ILogger<ConnectOpenWeatherMap>>(), new OWMSettings()
                {
                    APIKey = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.APIKey)}").Value,
                    OneCallAPI = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.OneCallAPI)}").Value,
                    ForecastUrl = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.ForecastUrl)}").Value,
                    CityPref = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.CityPref)}").Value,
                    Metric = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.Metric)}").Value,
                    Lat = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.Lat)}").Value,
                    Lon = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.Lon)}").Value
                }));
            builder.Services.AddScoped<ICityListProvider, CityListProvider>();
        }
    }
}
