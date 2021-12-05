using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Misc;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Shared.Client.ViewModels
{
    public class ShowWeatherDataViewModel
    {

        public WeatherForecastData Forecasts { get; private set; }
        private string[] CityList;
        private readonly HttpClient _httpClient;


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

        public ShowWeatherDataViewModel(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<string[]> GetCityList(string filter)
        {
            if(CityList == null)
            {
                CityList = new string[0];   
            }
            try
            {
                var list = await _httpClient.GetFromJsonAsync<CityData[]>($"api/citylist/{filter}");
                CityList = list.Select(t => t.Text).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CityList;

        }

        public async Task<string[]> GetCityList()
        {
            if (CityList == null)
                try
                {
                    var list = await _httpClient.GetFromJsonAsync<CityData[]>("api/citylist");
                    CityList = list.Select(t => t.Text).ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            return CityList;
        }


        public async Task GetForecast(string city)
        {
            try
            {
                string url = $"WeatherForecast/{city}";
                Console.WriteLine($"call:{_httpClient.BaseAddress}{url}");
                Forecasts = await _httpClient.GetFromJsonAsync<WeatherForecastData>(url);
            }
            catch (Exception ex)
            {
                Forecasts = new WeatherForecastData
                {
                    CityName = ex.Message,
                    CountryName = "CountryEx",
                    Weather = new WeatherData[] {
                    new WeatherData(){ DateTime = DateTime.Now , TemperatureFeelsLike = 25 , LooksLike = "LooksLike" , Temperature = 30 , LocationName ="Location" , WindDirection = 3 , WindSpeed = 12},
                    new WeatherData(){ DateTime = DateTime.Now.AddMinutes(1) , TemperatureFeelsLike = 25 , LooksLike = "LooksLike" , Temperature = 30 , LocationName ="Location" , WindDirection = 3 , WindSpeed = 12},
                    new WeatherData(){ DateTime = DateTime.Now.AddMinutes(2) , TemperatureFeelsLike = 25 , LooksLike = "LooksLike" , Temperature = 30 , LocationName ="Location" , WindDirection = 3 , WindSpeed = 12},
                    new WeatherData(){ DateTime = DateTime.Now.AddMinutes(3) , TemperatureFeelsLike = 25 , LooksLike = "LooksLike" , Temperature = 30 , LocationName ="Location" , WindDirection = 3 , WindSpeed = 12},
                    new WeatherData(){ DateTime = DateTime.Now.AddMinutes(4) , TemperatureFeelsLike = 25 , LooksLike = "LooksLike" , Temperature = 30 , LocationName ="Location" , WindDirection = 3 , WindSpeed = 12},
                    new WeatherData(){ DateTime = DateTime.Now.AddMinutes(5) , TemperatureFeelsLike = 25 , LooksLike = "LooksLike" , Temperature = 30 , LocationName ="Location" , WindDirection = 3 , WindSpeed = 12},
                    new WeatherData(){ DateTime = DateTime.Now.AddMinutes(6) , TemperatureFeelsLike = 25 , LooksLike = "LooksLike" , Temperature = 30 , LocationName ="Location" , WindDirection = 3 , WindSpeed = 12},
                    new WeatherData(){ DateTime = DateTime.Now.AddMinutes(7) , TemperatureFeelsLike = 25 , LooksLike = "LooksLike" , Temperature = 30 , LocationName ="Location" , WindDirection = 3 , WindSpeed = 12}
                }
                };
            }

        }

    }
}
