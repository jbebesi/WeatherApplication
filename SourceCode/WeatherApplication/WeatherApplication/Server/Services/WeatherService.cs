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
            _ILogger = logger;
            _WeatherService = weatherDataStore;
        }
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync(string city)
        {
            return await Task.FromResult(new WeatherForecast[] { 
                new WeatherForecast() { Date = DateTime.Now.AddHours(1) , Summary = "Temp 1" , TemperatureC = 12 } ,
                new WeatherForecast() { Date = DateTime.Now.AddHours(2) , Summary = "Temp 2" , TemperatureC = 15 }});
        }
    }
}
