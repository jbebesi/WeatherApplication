using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Shared.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApplication.Server.Controllers
{
    [Authorize]
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
        public IActionResult Get()
        {
            try
            {
                return Ok(_cityListProvider.GetCityList(""));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
                return BadRequest("Getting citylist failed");
            }
        }

        // GET api/<CityListController>/5
        [HttpGet("{filter}")]
        public IActionResult Get(string filter)
        {
            try
            {
                return Ok(_cityListProvider.GetCityList(filter));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
                return BadRequest("Filtering citylist is failed");
            }
        }
    }
}
