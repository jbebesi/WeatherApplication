using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Shared.Client.interfaces
{
    public interface IShowWeatherDataViewModel
    {
        public WeatherForecastData Forecasts { get; protected set; }
        Task<IEnumerable<string>> GetCityList();
        Task GetForecast(string city);
        Task<IEnumerable<string>> UpdateCityList(string filter);
    }
}
