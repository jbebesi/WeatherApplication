using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SubscriptionService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Shared;
using WeatherApplication.Shared.Dtos.Misc;

namespace SubscriptionService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {

        private readonly ILogger<SubscriptionsController> _logger;
        private readonly ISubscriptionInterface isubscriptionInterface;

        public SubscriptionsController(ILogger<SubscriptionsController> logger, ISubscriptionInterface isubscriptionInterface)
        {
            _logger = logger;
            this.isubscriptionInterface = isubscriptionInterface;
        }

        [HttpGet]
        public Subscription Get()
        {
            return this.isubscriptionInterface.GetSubscription("");
        }
    }
}
