using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Shared;
using WeatherApplication.Shared.Dtos.Misc;

namespace SubscriptionService.Interfaces
{
    public interface ISubscriptionService
    {
        public Subscription GetSubscription(string subscriptionName);
    }
}
