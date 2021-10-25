using SubscriptionService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Shared;

namespace SubscriptionService.Services
{
    public class SubscriptionService : ISubscriptionInterface
    {
        public Subscription GetSubscription(string subscriptionName)
        {
            return new Subscription()
            {
                FirstName = "TestFirst",
                ID = 123,
                LastName = "TestLast",
                SubscriberUntil = DateTime.Now.AddMinutes(1)
            };
        }
    }
}
