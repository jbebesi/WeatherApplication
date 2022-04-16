using Microsoft.Extensions.Logging;
using WeatherApplication.Shared.Dtos.Weather;
using WeatherApplication.Shared.Interfaces;

namespace WeatherApplication.Shared.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _ILogger;
        private readonly IWeatherDataStore _WeatherService;
        public WeatherService(ILogger<WeatherService> logger, IWeatherDataStore weatherDataStore)
        {
            _ILogger = logger ?? throw new ArgumentNullException(nameof(logger));
            _WeatherService = weatherDataStore ?? throw new ArgumentNullException(nameof(weatherDataStore));
        }
        public async Task<WeatherForecastData> GetWeatherForecastsAsync(string city)
        {
            try
            {
                return await _WeatherService.GetWeatherForecastsAsync(city);
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message, ex);
                return null;
            }
        }
    }
}
