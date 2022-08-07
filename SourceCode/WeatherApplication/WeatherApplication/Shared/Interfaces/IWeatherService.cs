using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Shared.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherForecastData> GetWeatherForecastsAsync(string city);

    }
}
