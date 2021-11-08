using System;

namespace WeatherApp.Shared.Data
{
    public struct CityData
    {
        public string Text => name + ", " + country;
        public int id;
        public string name;
        public string country;
        public Coordinate coord;

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
