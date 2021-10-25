using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Shared;

namespace SubscriptionService.Interfaces
{
    public interface ISubscriptionInterface
    {
        public Subscription GetSubscription(string subscriptionName);
    }
}
