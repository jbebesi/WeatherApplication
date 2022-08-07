using System;

namespace WeatherApplication.Shared.Dtos.Misc
{
    public class Subscription
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime SubscriberUntil { get; set; }
        public string MiddleName { get; set; }
        public int ID { get; set; }

    }
}
