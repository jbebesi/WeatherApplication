using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApplication.Server.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.Extensions.Logging;
using WeatherApplication.Server.Interfaces;
using System.Threading.Tasks;

namespace WeatherApplication.Server.Services.Tests
{
    [TestClass()]
    public class WeatherServiceTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeatherServiceTest_constructWithException()
        {
            var service = new WeatherService(null, null);
            Assert.IsNotNull(service);
        }

        [TestMethod()]
        public async Task WeatherServiceTest_GetData()
        {
            var logger = new Mock<ILogger<WeatherService>>();
            var store = new Mock<IWeatherDataStore>();

            var service = new WeatherService(logger.Object, store.Object);

            var res = await service.GetWeatherForecastsAsync("Budapest");

            Assert.IsNotNull(res);

        }
    }
}