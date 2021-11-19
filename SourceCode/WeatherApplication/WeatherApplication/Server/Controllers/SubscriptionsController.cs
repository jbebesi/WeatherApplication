using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApplication.Shared;
using WeatherApplication.Shared.Dtos.Misc;

namespace WeatherApplication.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {


        private readonly ILogger<SubscriptionsController> _logger;

        public SubscriptionsController(ILogger<SubscriptionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<Subscription> Get()
        {
            try
            {
                var client = new HttpClient() { BaseAddress = new Uri("http://subscriptionservice:80") };
                return await client.GetFromJsonAsync<Subscription>("Subscriptions");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,ex);
                return new Subscription() { FirstName= $"Message:{ex.Message}" };
            }
        }
    }
}
