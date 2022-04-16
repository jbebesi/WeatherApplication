namespace WeatherApplication.Shared.Dtos.Misc
{
    public struct CityData
    {
        public string Text => Name + ", " + Country;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Coordinate Coord { get; set; }

        public override string ToString()
        {
            return Text;
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
}
