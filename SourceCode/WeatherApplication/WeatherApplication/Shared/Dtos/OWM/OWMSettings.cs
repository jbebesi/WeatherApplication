namespace WeatherApplication.Shared.Dtos.OWM
{
    public class OWMSettings
    {
        public const string Settings = "OWMSettings";
        public string APIKey { get; set; }
        public string ForecastUrl { get; set; }
        public string OneCallAPI { get; set; }
        public string CityPref { get; set; }
        public string Metric { get; set; } 
        public string Lat { get; set; }
        public string Lon { get; set; }
        
    }
    public class PositionOptions
    {
        public const string Position = "Position";

        public string Title { get; set; }
        public string Name { get; set; }
    }
}
