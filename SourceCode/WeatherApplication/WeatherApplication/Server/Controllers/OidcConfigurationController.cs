﻿using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace WeatherApplication.Server.Controllers
{
    [AllowAnonymous]
    public class OidcConfigurationController : Controller
    {
        private readonly ILogger<OidcConfigurationController> _logger;

        public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider, ILogger<OidcConfigurationController> logger)
        {
            ClientRequestParametersProvider = clientRequestParametersProvider;
            _logger = logger;
        }

        public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            try
            {
                var parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
                return Ok(parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                return BadRequest($"Error happened + {ex.Message}");
            }
        }
    }
}