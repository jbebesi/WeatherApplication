using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Server.Interfaces;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Server.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _ILogger;
        private readonly IWeatherDataStore _WeatherService;
        public WeatherService (ILogger<WeatherService> logger, IWeatherDataStore weatherDataStore)
        {
            _ILogger = logger ?? throw new ArgumentNullException(nameof(logger));
            _WeatherService = weatherDataStore ?? throw new ArgumentNullException(nameof(weatherDataStore));
        }
        public async Task<WeatherForecastData> GetWeatherForecastsAsync(string city)
        {
            return  await _WeatherService.GetWeatherForecastsAsync(city);
        }
    }
}
