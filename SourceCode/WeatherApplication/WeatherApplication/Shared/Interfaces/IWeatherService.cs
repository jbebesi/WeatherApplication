using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Shared.Interfaces
{
    public interface IWeatherService
    {
        public Task<WeatherForecastData> GetWeatherForecastsAsync(string city);

    }
}
