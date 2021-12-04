//using OpenWeatherMap.Standard;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Misc;
using WeatherApplication.Shared.Dtos.OWM;
using WeatherApplication.Shared.Dtos.Weather;
using WeatherApplication.Shared.Interfaces;

namespace WeatherApplication.Shared.Services.OWM
{
    public class ConnectOpenWeatherMap : IWeatherProvider
    {

        private readonly OWMSettings _settings;
        private readonly List<CityData> mCityList;
        private readonly ILogger<ConnectOpenWeatherMap> _logger;

        private readonly HttpClient _httpClient;

        public ConnectOpenWeatherMap(HttpClient httpClient, IConfiguration configuration, ILogger<ConnectOpenWeatherMap> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
            _settings = new OWMSettings();
        }

        public async Task<WeatherData> GetCityData(string city)
        {
            try
            {
                HttpResponseMessage resp = await _httpClient.GetAsync(_settings.CityPref + city + _settings.Metric + _settings.APIKey).ConfigureAwait(false);
                if (resp.Content != null)
                {
                    string responseString = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Console.WriteLine(responseString);
                    return (WeatherData)JsonConvert.DeserializeObject<OWMWeatherData>(responseString);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return new WeatherData();
        }

        public async Task<WeatherData> GetLocationData(LocationData location)
        {
            try
            {
                string rString = _settings.Lat + location.Latitude + _settings.Lon + location.Longitude;
                HttpResponseMessage resp = await _httpClient.GetAsync(rString + _settings.Metric + _settings.APIKey).ConfigureAwait(false);
                if (resp.Content != null)
                {
                    string responseString = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Console.WriteLine(responseString);
                    return (WeatherData)JsonConvert.DeserializeObject<OWMWeatherData>(responseString);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return new WeatherData();
        }


        public async Task<WeatherForecastData> GetCityForecast(string city)
        {
            try
            {
                var query = $"{_settings.ForecastUrl}?{_settings.CityPref}{city}&units=metric&{_settings.APIKey}";
                OWMForecast resp = await _httpClient.GetFromJsonAsync<OWMForecast>(query).ConfigureAwait(false);
                return resp.ToWeatherForecastData();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return new WeatherForecastData();
        }
        public async Task<WeatherForecastData> GetLocationForecast(LocationData location)
        {
            try
            {
                var query = $"{_settings.OneCallAPI}?{_settings.Lat}{location.Latitude}{_settings.Lon}{location.Longitude}{_settings.APIKey}";

                HttpResponseMessage resp = await _httpClient.GetAsync(query).ConfigureAwait(false);
                if (resp.Content != null)
                {
                    string responseString = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var data = JsonConvert.DeserializeObject<OWMWeatherData>(responseString);
                    return new WeatherForecastData() { Weather = new WeatherData[] { (WeatherData)data } };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return new WeatherForecastData();
        }
    }
}
