using WeatherApplication.Shared.Dtos.Misc;
using WeatherApplication.Shared.Helpers;
using WeatherApplication.Shared.Interfaces;

namespace WeatherApplication.Shared.Services
{
    public class CityListProvider : ICityListProvider
    {
        private readonly List<CityData> _cityList;

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
