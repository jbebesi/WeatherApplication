using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApplication.Shared
{
    public class Subscription
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }

        public DateTime SubscriberUntil {  get; set; }  
        public string MiddleName { get; set; }
        public int ID { get; set; }

    }
}
