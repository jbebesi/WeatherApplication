using WeatherApplication.Shared.Dtos.Misc;

namespace SubscriptionService.Interfaces
{
    public interface ISubscriptionService
    {
        public Subscription GetSubscription(string subscriptionName);
    }
}
