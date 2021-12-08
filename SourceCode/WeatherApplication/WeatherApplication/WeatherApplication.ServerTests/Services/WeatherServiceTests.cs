using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using WeatherApplication.Shared.Interfaces;
using WeatherApplication.Shared.Services;

namespace WeatherApplication.ServerTests.Services
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