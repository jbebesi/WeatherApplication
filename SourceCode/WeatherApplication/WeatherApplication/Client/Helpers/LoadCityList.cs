using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Misc;

namespace WeatherApplication.Client.Helpers
{
    public class LoadCityList
    {
        private static List<CityData> _cityList = null;
        public static List<CityData> GetCityList()
        {
            try
            {
                if (_cityList == null)
                {
                    string s = System.Text.Encoding.UTF8.GetString(Properties.Resources.city_list);
                    _cityList = JsonConvert.DeserializeObject<List<CityData>>(s).Take(20).ToList();
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
