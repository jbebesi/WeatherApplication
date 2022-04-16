using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Shared.Interfaces
{
    public interface IWeatherService
    {
        public Task<WeatherForecastData> GetWeatherForecastsAsync(string city);

    }
}
