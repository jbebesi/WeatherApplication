//using OpenWeatherMap.Standard;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Shared.Data;
using WeatherApplication.Server.Dtos.OWM;
using WeatherApplication.Server.Interfaces;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Server.OpenWeatherMap
{
    public class ConnectOpenWeatherMap : IWeatherProvider
    {

        private readonly OWMSettings _settings;
        private readonly List<CityData> mCityList;
        //List<CityData> IWeatherProvider.CityList => mCityList;
        private readonly ILogger<ConnectOpenWeatherMap> _logger;

        private readonly HttpClient _httpClient;

        public ConnectOpenWeatherMap(HttpClient httpClient, IConfiguration configuration, ILogger<ConnectOpenWeatherMap> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
            var section = configuration.GetSection($"{ OWMSettings.Settings}");
            _settings = section.Get<OWMSettings>();


            //string s = System.Text.Encoding.UTF8.GetString(Properties.Resources.city_list);
            //mCityList = JsonConvert.DeserializeObject<List<CityData>>(s);
            _httpClient.BaseAddress = new Uri(_settings.Url);
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
                _logger.LogError(ex.Message,ex);
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

        public async Task<WeatherForecastData> GetLocationForecast(LocationData location)
        {
            try
            {
                string rString = _settings.Lat + location.Latitude + _settings.Lon + location.Longitude;
                HttpResponseMessage resp = await _httpClient.GetAsync(_settings.Forecast + rString + _settings.Metric + _settings.APIKey).ConfigureAwait(false);
                if (resp.Content != null)
                {
                    string responseString = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<OWMWeatherForecastData>(responseString);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return new WeatherForecastData();
        }

        public async Task<WeatherForecastData> GetCityForecast(string city)
        {
            try
            {
                HttpResponseMessage resp = await _httpClient.GetAsync(_settings.Forecast + _settings.CityPref + city + _settings.Metric + _settings.APIKey).ConfigureAwait(false);
                if (resp.Content != null)
                {
                    string responseString = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<OWMWeatherForecastData>(responseString);
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
