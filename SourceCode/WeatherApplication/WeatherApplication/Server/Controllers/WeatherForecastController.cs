using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Server.Interfaces;
using WeatherApplication.Shared;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherProvider) 
        { 
            _logger = logger;  
            _weatherService = weatherProvider; 
        }

        [HttpGet]
        public async Task<WeatherForecastData> Get()
        {
            _logger.LogInformation("Get called");
            return await _weatherService.GetWeatherForecastsAsync("Budapest");
        }
    }
}
