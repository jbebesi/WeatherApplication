﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Misc;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Server.Interfaces
{
    public interface IWeatherProvider
    {
        Task<WeatherData> GetCityData(string name);
        Task<WeatherData> GetLocationData(LocationData location);
        Task<WeatherForecastData> GetLocationForecast(LocationData location);
        Task<WeatherForecastData> GetCityForecast(string name);
    }
}
