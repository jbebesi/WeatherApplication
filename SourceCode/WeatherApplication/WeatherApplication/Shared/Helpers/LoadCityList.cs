using Newtonsoft.Json;
using WeatherApplication.Shared.Dtos.Misc;

namespace WeatherApplication.Shared.Helpers
{
    public static class LoadCityList
    {
        private static List<CityData> _cityList;
        public static List<CityData> GetCityList()
        {
            if (_cityList == null)
            {
                string s = System.Text.Encoding.UTF8.GetString(Properties.Resources.city_list);
                _cityList = JsonConvert.DeserializeObject<List<CityData>>(s).ToList();
            }
            return _cityList;
        }
    }
}
