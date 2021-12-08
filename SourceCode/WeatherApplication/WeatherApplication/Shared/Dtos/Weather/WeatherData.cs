using System;

namespace WeatherApplication.Shared.Dtos.Weather
{
    public struct WeatherData
    {
        public enum DataType
        {
            Temperature,
            Wind,
            TemperatureFeelsLike,
            WindDirection
        }

        public short Temperature { get; set; }
        public short TemperatureMin { get; set; }
        public short TemperatureMax { get; set; }
        public short TemperatureFeelsLike { get; set; }
        public string LooksLike { get; set; }
        public short WindSpeed { get; set; }
        public double WindDirection { get; set; }
        public string LocationName { get; set; }
        public DateTime DateTime { get; set; }

        public WeatherData(short nTemperature, short nTemperatureFeelsLike, string nLooksLike, short nWindSpeed, double nWindDirection, string nLocationName, DateTime nDateTime, short nTempMax, short nTempMin)
        {
            Temperature = nTemperature;
            TemperatureFeelsLike = nTemperatureFeelsLike;
            LooksLike = nLooksLike;
            WindSpeed = nWindSpeed;
            WindDirection = nWindDirection;
            LocationName = nLocationName;
            DateTime = nDateTime;
            TemperatureMax = nTempMax;
            TemperatureMin = nTempMin;
        }

        public int this[DataType data]
        {
            get
            {
                return data switch
                {
                    DataType.Temperature => Temperature,
                    DataType.Wind => WindSpeed,
                    DataType.TemperatureFeelsLike => TemperatureFeelsLike,
                    DataType.WindDirection => (int)WindDirection,
                    _ => throw new ArgumentException("Argument not supported:" + data.ToString()),
                };
            }
        }
    }

    public class WeatherForecastData
    {
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public WeatherData[] Weather { get; set; }
    }
}
