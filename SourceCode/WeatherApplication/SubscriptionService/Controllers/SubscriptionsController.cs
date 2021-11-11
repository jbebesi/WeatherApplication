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
        private readonly ISubscriptionService _iSubscriptionInterface;

        public SubscriptionsController(ILogger<SubscriptionsController> logger, ISubscriptionService isubscriptionInterface)
        {
            _logger = logger;
            _iSubscriptionInterface = isubscriptionInterface;
        }

        [HttpGet]
        public Subscription Get()
        {
            return _iSubscriptionInterface.GetSubscription("");
        }
    }
}
