using Microsoft.AspNetCore.Mvc;

namespace WeatherApplication.Server.Controllers
{

    public class IdentityController : Controller
    {
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(ILogger<IdentityController> logger)
        {
            _logger = logger;
        }


        [HttpGet(".well-known/openid-configuration")]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            try
            {
                return Ok("Identity success: .well-known/openid-configuration");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
                return BadRequest("Getting citylist failed");
            }
        }
    }
}
