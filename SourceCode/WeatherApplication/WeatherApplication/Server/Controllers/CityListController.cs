using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApplication.Shared.Dtos.Misc;
using WeatherApplication.Shared.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityListController : ControllerBase
    {
        private readonly ILogger<CityListController> _logger;
        private readonly ICityListProvider _cityListProvider;

        public CityListController(ILogger<CityListController> logger, ICityListProvider cityListProvider)
        {
            _logger = logger;
            _cityListProvider = cityListProvider;
        }

        // GET: api/<CityListController>
        [HttpGet()]
        public async Task<IEnumerable<CityData>> Get()
        {
            var result = _cityListProvider.GetCityList("");
            return await Task.FromResult(result);
        }

        // GET api/<CityListController>/5
        [HttpGet("{filter}")]
        public async Task<IEnumerable<CityData>> Get(string filter)
        {
            var result = _cityListProvider.GetCityList(filter);
            return await Task.FromResult(result);
        }
    }
}
