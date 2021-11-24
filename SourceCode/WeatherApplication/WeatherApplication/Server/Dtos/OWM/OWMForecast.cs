using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Server.Dtos.OWM
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }


    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }

    public class Sys
    {
        public string pod { get; set; }
    }

    public class Rain
    {
        public double _3h { get; set; }
    }

    public class OWMWeather
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public int visibility { get; set; }
        public double pop { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
        public Rain rain { get; set; }

        public WeatherData ToWeatherData()
        {
            return new WeatherData()
            {
                DateTime = new DateTime(dt),
                TemperatureFeelsLike = (short)main.feels_like,
                TemperatureMin = (short)main.temp_min,
                TemperatureMax = (short)main.temp_max,
                Temperature = (short)main.temp,
                WindDirection = wind.deg,
                WindSpeed = (short)wind.speed,
            };
        }
    }

    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class OWMForecast
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<OWMWeather> list { get; set; }
        public City city { get; set; }

        public WeatherForecastData ToWeatherForecastData()
        {
            return new WeatherForecastData()
            {
                CityName = city.name,
                CountryName = city.country,
                Weather = list.Select(t=>t.ToWeatherData()).ToArray()
            };
        }
    }


}
