using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Server.interfaces;

namespace WeatherApplication.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {


        private readonly ILogger<SubscriptionsController> _logger;
        private readonly ISubscriptionHelper _subscriptionHelper;

        public SubscriptionsController(ILogger<SubscriptionsController> logger, ISubscriptionHelper subscriptionHelper)
        {
            _logger = logger;
            _subscriptionHelper = subscriptionHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //var client = new HttpClient() { BaseAddress = new Uri("http://subscriptionservice:80") };
                //return await client.GetFromJsonAsync<Subscription>("Subscriptions");
                return Ok(await _subscriptionHelper.GetApplicationUsersAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest($"Message:{ex.Message}");
            }
        }
    }
}
