using System.Collections.Generic;
using WeatherApplication.Shared.Dtos.Misc;

namespace WeatherApplication.Shared.Interfaces
{
    public interface ICityListProvider
    {
        public IEnumerable<CityData> GetCityList(string filter, int maxCount);
        public IEnumerable<CityData> GetCityList(string filter);
    }
}
