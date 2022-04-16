using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Shared.Dtos.OWM
{
    public struct OWMWeatherData
    {
        public int Id { get; set; }
        public int Dt { get; set; }
        public DateTime Dt_txt { get; set; }
        public string Name { get; set; }
        public Coordinate Coord { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public List<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Rain Rain { get; set; }
        public Rain Snow { get; set; }

        public static explicit operator WeatherData(OWMWeatherData data)
        {
            return new WeatherData(
                (short)data.Main.Temp,
                (short)data.Main.Temp_max,
                data.Name,
                (short)data.Wind.Speed,
                data.Wind.Deg,
                data.Name,
                data.Dt_txt,
                short.MinValue,
                short.MaxValue);
        }
    }

    public struct Coordinate
    {
        public double Lat { get; set; }
        public double Lon { get; set; }

        public override string ToString()
        {
            return "\tLat=" + Lat.ToString() + Environment.NewLine +
                "\tLon=" + Lon.ToString() + Environment.NewLine;
        }
    }


    public struct Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public override string ToString()
        {
            return "\tmain=" + Main + Environment.NewLine +
                "\tdescription=" + Description + Environment.NewLine +
                "\ticon=" + Icon + Environment.NewLine;
        }
    }

    public struct Clouds
    {
        //cloudiness, %
        public int All { get; set; }

        public override string ToString()
        {
            return "\tall=" + All.ToString() + Environment.NewLine;
        }
    }


    public struct OWMWeatherForecastData
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public int Cnt { get; set; }
        public OWMWeatherData[] List { get; set; }
        public OWMCity City { get; set; }

        public static implicit operator WeatherForecastData(OWMWeatherForecastData data)
        {
            return new WeatherForecastData
            {
                Weather = data.List.ToList().ConvertAll(t => (WeatherData)t).ToArray(),
                CityName = data.City.Name,
                CountryName = data.City.Country
            };
        }
    }

    public struct OWMCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coordinate Coord { get; set; }
        public string Country { get; set; }
        // Shift in seconds from UTC
        public int TimeZone { get; set; }
        public int Population { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}
