using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Weather;
using WeatherApplication.Shared.Interfaces;

namespace WeatherApplication.Shared.Services
{
    public class WeatherDataStore : IWeatherDataStore
    {

        private readonly ILogger<WeatherDataStore> _logger;
        private readonly IWeatherProvider _weatherProvider;

        private Dictionary<string, Tuple<WeatherForecastData, DateTime>> _storedWeatherData;

        public WeatherDataStore(ILogger<WeatherDataStore> logger, IWeatherProvider weatherProvider)
        {
            _logger = logger;
            _weatherProvider = weatherProvider;
            _storedWeatherData = new Dictionary<string, Tuple<WeatherForecastData, DateTime>>();
        }

        public async Task<WeatherForecastData> GetWeatherForecastsAsync(string city)
        {
            if (_storedWeatherData.ContainsKey(city))
            {
                var result = _storedWeatherData[city];
                if (result.Item2.Date.AddHours(4) < DateTime.Now)
                    return result.Item1;
                else
                {
                    _storedWeatherData.Remove(city);
                }
            }
            var updated = await _weatherProvider.GetCityForecast(city);
            _storedWeatherData.Add(city, Tuple.Create(updated, DateTime.Now));
            return updated;
        }
    }
}
