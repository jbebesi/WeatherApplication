using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Shared.Dtos.OWM
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Main
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Sea_level { get; set; }
        public int Grnd_level { get; set; }
        public int Humidity { get; set; }
        public double Temp_kf { get; set; }
    }


    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class Sys
    {
        public string Pod { get; set; }
    }

    public class Rain
    {
        public double _3h { get; set; }
    }

    public class OWMWeather
    {
        public int Dt { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public int Visibility { get; set; }
        public double Pop { get; set; }
        public Sys Sys { get; set; }
        public string Dt_txt { get; set; }
        public Rain Rain { get; set; }

        public WeatherData ToWeatherData()
        {
            return new WeatherData()
            {
                DateTime = new DateTime(Dt),
                TemperatureFeelsLike = (short)Main.Feels_like,
                TemperatureMin = (short)Main.Temp_min,
                TemperatureMax = (short)Main.Temp_max,
                Temperature = (short)Main.Temp,
                WindDirection = Wind.Deg,
                WindSpeed = (short)Wind.Speed,
            };
        }
    }

    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class City
    {
        public City(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public int Timezone { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class OWMForecast
    {
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<OWMWeather> List { get; set; }
        public City City { get; set; }

        public WeatherForecastData ToWeatherForecastData()
        {
            return new WeatherForecastData()
            {
                CityName = City.Name,
                CountryName = City.Country,
                Weather = List.Select(t => t.ToWeatherData()).ToArray()
            };
        }
    }
}
