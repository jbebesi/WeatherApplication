using System;

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
        public double lat;
        public double lon;

        public override string ToString()
        {
            return "\tLat=" + lat.ToString() + Environment.NewLine +
                "\tLon=" + lon.ToString() + Environment.NewLine;
        }
    }
}
