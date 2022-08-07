using System.Collections.Generic;

namespace WeatherApplication.Shared.Dtos.OWM
{

    public class Current
    {
        public int Dt { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Dew_point { get; set; }
        public int Uvi { get; set; }
        public int Clouds { get; set; }
        public int Visibility { get; set; }
        public double Wind_speed { get; set; }
        public int Wind_deg { get; set; }
        public double Wind_gust { get; set; }
        public List<Weather> Weather { get; set; }
    }

    public class Minutely
    {
        public int Dt { get; set; }
        public int Precipitation { get; set; }
    }

    public class Hourly
    {
        public int Dt { get; set; }
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Dew_point { get; set; }
        public double Uvi { get; set; }
        public int Clouds { get; set; }
        public int Visibility { get; set; }
        public double Wind_speed { get; set; }
        public int Wind_deg { get; set; }
        public double Wind_gust { get; set; }
        public List<Weather> Weather { get; set; }
        public int Pop { get; set; }
    }

    public class Temp
    {
        public double Day { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Night { get; set; }
        public double Eve { get; set; }
        public double Morn { get; set; }
    }

    public class FeelsLike
    {
        public double Day { get; set; }
        public double Night { get; set; }
        public double Eve { get; set; }
        public double Morn { get; set; }
    }

    public class Daily
    {
        public int Dt { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public int Moonrise { get; set; }
        public int Moonset { get; set; }
        public double Moon_phase { get; set; }
        public Temp Temp { get; set; }
        public FeelsLike Feels_like { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Dew_point { get; set; }
        public double Wind_speed { get; set; }
        public int Wind_deg { get; set; }
        public double Wind_gust { get; set; }
        public List<Weather> Weather { get; set; }
        public int Clouds { get; set; }
        public double Pop { get; set; }
        public double Uvi { get; set; }
        public double? Rain { get; set; }
    }

    public class Root
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Timezone { get; set; }
        public int Timezone_offset { get; set; }
        public Current Current { get; set; }
        public List<Minutely> Minutely { get; set; }
        public List<Hourly> Hourly { get; set; }
        public List<Daily> Daily { get; set; }
    }
}