using System.Collections.Generic;
using WeatherApplication.Shared.Dtos.Misc;
using System.Linq;
using WeatherApplication.Shared.Interfaces;
using WeatherApplication.Shared.Helpers;

namespace WeatherApplication.Shared.Services
{
    public class CityListProvider : ICityListProvider
    {
        private List<CityData> _cityList;

        public CityListProvider()
        {
            _cityList = LoadCityList.GetCityList();
        }

        public IEnumerable<CityData> GetCityList(string filter, int maxCount)
        {
            return _cityList.Where(t => t.Text.Contains(filter)).Take(maxCount).ToList();
        }

        public IEnumerable<CityData> GetCityList(string filter)
        {
            return GetCityList(filter, 60);
        }
    }
}
