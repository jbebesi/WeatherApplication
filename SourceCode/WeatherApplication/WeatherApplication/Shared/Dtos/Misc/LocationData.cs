using System;

namespace WeatherApplication.Shared.Dtos.Misc
{
    public struct LocationData
    {
        public readonly double Altitude;
        public readonly double Latitude;
        public readonly double Longitude;

        public LocationData(double nAltitude, double nLatitude, double nLongitude)
        {
            Altitude = nAltitude;
            Latitude = nLatitude;
            Longitude = nLongitude;
        }

        public double Distance(LocationData other)
        {
            return Math.Sqrt(Math.Pow(Latitude - other.Latitude, 2) +
                Math.Pow(Longitude - other.Longitude, 2));
        }
    }
}
