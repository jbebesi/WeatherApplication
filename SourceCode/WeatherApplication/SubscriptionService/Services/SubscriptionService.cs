using SubscriptionService.Interfaces;
using System;
using WeatherApplication.Shared.Dtos.Misc;

namespace SubscriptionService.Services
{
    public class SubscriptionService : ISubscriptionService
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
