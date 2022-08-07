using System.Collections.Generic;
using WeatherApplication.Shared.Dtos.Misc;

namespace WeatherApplication.Shared.Interfaces
{
    public interface ICityListProvider
    {
        IEnumerable<CityData> GetCityList(string filter, int maxCount);
        IEnumerable<CityData> GetCityList(string filter);
    }
}
