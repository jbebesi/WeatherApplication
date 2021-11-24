namespace WeatherApplication.Server.Dtos.OWM
{
    public class OWMSettings
    {
        public const string Settings = "OWMSettings";
        public string APIKey { get; set; } = "appid=f51a448c4adeafb7f7a85f4cd20b8237";
        public string ForecastUrl { get; set; } = "http://api.openweathermap.org/data/2.5/forecast";
        public string OneCallAPI { get; set; } = "https://api.openweathermap.org/data/2.5/onecall";
        public string CityPref { get; set; } = "q=";
        public string Metric { get; set; } = "";
        public string Lat { get; set; } = "lat=";
        public string Lon { get; set; } = "lon=";
    }
    public class PositionOptions
    {
        public const string Position = "Position";

        public string Title { get; set; }
        public string Name { get; set; }
    }
}
