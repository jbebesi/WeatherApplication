using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Server.Dtos.OWM
{
    public struct OWMWeatherData
    {
        public int id;
        public int dt;
        public DateTime dt_txt;
        public string name;
        public Coordinate coord;
        public Main main;
        public Wind wind;
        public List<Weather> weather;
        public Clouds clouds;
        public Rain rain;
        public Rain snow;

        public static explicit operator WeatherData(OWMWeatherData data)
        {
            return new WeatherData(
                (short)data.main.temp,
                (short)data.main.temp_max,
                data.name,
                (short)data.wind.speed,
                data.wind.deg,
                data.name,
                data.dt_txt,
                short.MinValue,
                short.MaxValue);
        }
    }

    public struct Coordinate
    {
        public double lat;
        public double lon;

        public override string ToString()
        {
            return "\tLat=" + lat.ToString() + Environment.NewLine +
                "\tLon=" + lon.ToString() + Environment.NewLine;
        }
    }
  

    public struct Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;

        public override string ToString()
        {
            return "\tmain=" + main + Environment.NewLine +
                "\tdescription=" + description + Environment.NewLine +
                "\ticon=" + icon + Environment.NewLine;
        }
    }

    public struct Clouds
    {
        //cloudiness, %
        public int all;

        public override string ToString()
        {
            return "\tall=" + all.ToString() + Environment.NewLine;
        }
    }


    public struct OWMWeatherForecastData
    {
        public int code;
        public string message;
        public int cnt;
        public OWMWeatherData[] list;
        public OWMCity city;

        public static implicit operator WeatherForecastData(OWMWeatherForecastData data)
        {
            return new WeatherForecastData
            {
                Weather = data.list.ToList().ConvertAll<WeatherData>(t => (WeatherData)t).ToArray(),
                CityName = data.city.Name,
                CountryName = data.city.Country
            };
        }
    }

    public struct OWMCity
    {
        public int Id;
        public string Name;
        public Coordinate Coord;
        public string Country;
        // Shift in seconds from UTC
        public int TimeZone;
        public int Population;
        public int Sunrise;
        public int Sunset;
    }
}
