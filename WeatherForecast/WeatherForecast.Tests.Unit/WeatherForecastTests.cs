using System.Linq;
using NUnit.Framework;
using Moq;
using WeatherForecast.Model;
using WeatherForecast.Query;

namespace WeatherForecast.Tests.Unit
{
    public class WeatherForecastTests
    {
        private Mock<ISevenDayTemperatures> _mockSevenDayTemperatures;
        private SevenDayForecast _sevenDayForecast;
        private int _expectedAvgTemperature;

        [OneTimeSetUp]
        public void GivenAWeatherForecast_WhenASevenDayForecastIsRequested()
        {
            int[] expectedTemperatures = {12, 13, 10, 8, 26, 27, 19};
            _expectedAvgTemperature = expectedTemperatures.Sum() / 7;

            _mockSevenDayTemperatures = new Mock<ISevenDayTemperatures>();
            _mockSevenDayTemperatures.Setup(x => x.GetSevenDayTemperatures()).Returns(expectedTemperatures);

            var weatherForecast = new Query.WeatherForecast(_mockSevenDayTemperatures.Object);
            _sevenDayForecast = weatherForecast.GetSevenDayForecast();
        }

        [Test]
        public void ThenTheSevenDayTemperatureRequestIsMade()
        {
            _mockSevenDayTemperatures.Verify(x => x.GetSevenDayTemperatures(), Times.Once);   
        }

        [Test]
        public void ThenTheAverageTemperatureIsCorrect()
        {
            Assert.That(_sevenDayForecast.AverageTemperature, Is.EqualTo(_expectedAvgTemperature));            
        }
    }
}
