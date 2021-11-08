using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Shared.Data;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Server.Interfaces
{
    public interface IWeatherProvider
    {
        //List<CityData> CityList { get; }
        Task<WeatherData> GetCityData(string name);
        Task<WeatherData> GetLocationData(LocationData location);
        Task<WeatherForecastData> GetLocationForecast(LocationData location);
        Task<WeatherForecastData> GetCityForecast(string name);
    }
}
