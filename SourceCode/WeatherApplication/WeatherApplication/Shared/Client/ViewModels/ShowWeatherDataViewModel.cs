using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApplication.Shared.Client.interfaces;
using WeatherApplication.Shared.Dtos.Misc;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Shared.Client.ViewModels
{
    public class ShowWeatherDataViewModel : IShowWeatherDataViewModel
    {
        public WeatherForecastData Forecasts { get; set; }
        private List<string> CityList;
        private readonly HttpClient _httpClient;
        private readonly ILogger<ShowWeatherDataViewModel> _logger;
        private string selected;
        
        public string SelectedCity
        {
            get => selected;
            set
            {
                selected = value;
                GetForecast(value).Wait();
            }
        }

        public ShowWeatherDataViewModel(HttpClient client, ILogger<ShowWeatherDataViewModel> logger)
        {
            _httpClient = client ?? throw new ArgumentNullException($"{nameof(client)} can not be null!");
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} can not be null!");
        }

        public async Task<IEnumerable<string>> UpdateCityList(string filter)
        {
            if (CityList == null)
            {
                CityList = new List<string>();
            }
            try
            {
                var list = await _httpClient.GetFromJsonAsync<CityData[]>($"api/citylist/{filter}");
                CityList.AddRange(list.Select(t => t.Text).Where(t=>!CityList.Contains(t)));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
            }
            return CityList;

        }

        public async Task<IEnumerable<string>> GetCityList()
        {
            if (CityList == null)
                try
                {
                    var list = await _httpClient.GetFromJsonAsync<CityData[]>("api/citylist");
                    CityList = list.Select(t => t.Text).ToList();
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex.Message, ex);
                }
            return CityList;
        }

        public async Task GetForecast(string city)
        {
            try
            {
                string url = $"WeatherForecast/{city}";
                Forecasts = await _httpClient.GetFromJsonAsync<WeatherForecastData>(url);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
            }
        }
    }
}
