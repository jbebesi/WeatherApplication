using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Misc;

namespace WeatherApplication.Client.HttpClients
{
    public class SubscriptionHttpClient : HttpClient
    {

        public async Task<Subscription> GetSubscription(string ID)
        {
            return await this.GetFromJsonAsync<Subscription>("Subscriptions");
        }
    }
}
