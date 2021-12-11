using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApplication.Shared.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Moq;
using Moq.Protected;
using System.Threading;
using WeatherApplication.Shared.Dtos.Misc;
using WeatherApplication.Shared.Dtos.Weather;

namespace WeatherApplication.Shared.Client.ViewModels.Tests
{
    [TestClass()]
    public class ShowWeatherDataViewModelTests
    {
        private const int cNumberOfCitiesTaken = 5;
        Mock<HttpMessageHandler>? _handler;

        ShowWeatherDataViewModel CreateModel()
        {
            _handler = new Mock<HttpMessageHandler>();
            var result = new ShowWeatherDataViewModel(new HttpClient(_handler.Object) { BaseAddress= new Uri("http://localhost:80/")});
            return result;
        }
        void AddCitysToHandler()
        {
            _handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Returns(async (HttpRequestMessage request, CancellationToken token) => {
                HttpResponseMessage response = new HttpResponseMessage();
                CityData[] cityList = new CityData[] 
                    { 
                        new CityData(){ Country="T" , Name = "Test11" },
                        new CityData(){ Country="T" , Name = "Test12" },
                        new CityData(){ Country="T" , Name = "Test13" },
                        new CityData(){ Country="T" , Name = "Test24" },
                        new CityData(){ Country="T" , Name = "Test25" },
                        new CityData(){ Country="T" , Name = "Test26" },
                        new CityData(){ Country="T" , Name = "Test27" },
                        new CityData(){ Country="T" , Name = "Test28" },
                        new CityData(){ Country="T" , Name = "Test49" },
                        new CityData(){ Country="T" , Name = "Test4A" },
                        new CityData(){ Country="T" , Name = "Test4B" },
                        new CityData(){ Country="T" , Name = "Test4C" },
                        new CityData(){ Country="T" , Name = "Test4D" }
                    };
                IEnumerable<CityData> res; ;
                var search = request.RequestUri.AbsolutePath.Split("api/citylist/");
                if(search.Length >1)
                {
                    res = cityList.Where(t => t.Name.Contains(search[1])).Take(cNumberOfCitiesTaken);
                }
                else
                {
                    res = cityList.Take(cNumberOfCitiesTaken);
                }
                response.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(res));
                return response;
            })
            .Verifiable();
        }
        void AddWeatherToHandler()
        {
            _handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Returns(async (HttpRequestMessage request, CancellationToken token) => {
                HttpResponseMessage response = new HttpResponseMessage();

                var weather = new WeatherForecastData() { 
                    CityName = "TestCity" , 
                    CountryName = "TestCountry" , 
                    Weather = new WeatherData[] { 
                        new WeatherData(){ },
                        new WeatherData(){ }
                    } 
                };
                response.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(weather));
                return response;
            })
            .Verifiable();
        }

        [TestMethod()]
        public void ShowWeatherDataViewModelTest()
        {
            Assert.IsNotNull(CreateModel());
        }

        [TestMethod()]
        public async Task UpdateCityListTest()
        {
            var model = CreateModel();
            AddCitysToHandler();
            var cityList =await model.GetCityList();
            Assert.IsNotNull(cityList);
            Assert.AreEqual(5, cityList.Count());
            cityList = await model.UpdateCityList("2");
            Assert.IsNotNull(cityList);
            Assert.IsTrue(cityList.Count() > 6);

        }

        [TestMethod()]
        public async Task GetForecastTest()
        {
            var model = CreateModel();
            AddWeatherToHandler();
            await model.GetForecast("TestCity");
            Assert.IsNotNull(model.Forecasts);
            Assert.AreEqual(model.Forecasts.CityName, "TestCity");

        }
    }
}