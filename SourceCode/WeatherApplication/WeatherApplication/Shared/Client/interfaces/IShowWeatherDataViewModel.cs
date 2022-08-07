using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Shared.Client.interfaces
{
    public interface IShowWeatherDataViewModel
    {
        WeatherForecastData Forecasts { get; set; }
        Task<IEnumerable<string>> GetCityList();
        Task GetForecast(string city);
        Task<IEnumerable<string>> UpdateCityList(string filter);
    }
}
