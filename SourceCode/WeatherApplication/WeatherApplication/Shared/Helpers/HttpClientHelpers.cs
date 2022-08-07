using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.Shared.Helpers
{
    public static class HttpClientHelpers
    {
        public static async Task<T> GetFromJsonAsync<T>(this HttpClient client, string uri)
        {
            var response = await client.GetAsync(uri);
            var respStr = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(respStr);
            
        }
        
    }
}
