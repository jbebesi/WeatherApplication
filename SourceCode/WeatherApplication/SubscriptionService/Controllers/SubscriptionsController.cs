using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SubscriptionService.Interfaces;
using System;
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
            try
            {
                return _iSubscriptionInterface.GetSubscription("");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
                return null;
            }
        }
    }
}
