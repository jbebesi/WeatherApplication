using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WeatherApplication.Shared.Dtos.Misc;

namespace WeatherApplication.Shared.Helpers
{
    public class LoadCityList
    {
        private static List<CityData> _cityList;
        public static List<CityData> GetCityList()
        {
            try
            {
                if (_cityList == null)
                {
                    string s = System.Text.Encoding.UTF8.GetString(Properties.Resources.city_list);
                    _cityList = JsonConvert.DeserializeObject<List<CityData>>(s).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _cityList;
        }
    }
}
