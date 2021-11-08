using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Shared;
using WeatherApplication.Shared.Dtos.Misc;

namespace WeatherApplication.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {


        private readonly ILogger<SubscriptionsController> logger;

        public SubscriptionsController(ILogger<SubscriptionsController> logger)
        {
            this.logger = logger;
        }

        //<IEnumerable<Subscription>>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new Subscription[] { new Subscription() { FirstName="Jo" , LastName = "Smith", MiddleName = "Jones", SubscriberUntil= DateTime.Now.AddDays(2), ID = 1 } });
        }
    }
}
