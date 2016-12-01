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
        private Mock<IDaylightReport> _mockDaylightReport;
        private SevenDayForecast _sevenDayForecast;
        private SevenDayForecast _daylightReportForecast;
        private int _expectedAvgTemperature;
        private string _expectedOverallDaylightReport;

        [OneTimeSetUp]
        public void GivenAWeatherForecast_WhenASevenDayForecastIsRequested()
        {
            int[] expectedTemperatures = { 12, 13, 10, 8, 26, 27, 19 };
            _expectedAvgTemperature = expectedTemperatures.Sum() / 7;

            string[] expectedDaylightReport = {"Cloudy", "Sunny", "Cloudy", "Cloudy", "Sunny", "Sunny", "Sunny"};
            _expectedOverallDaylightReport = "Mostly Sunny";

            _mockSevenDayTemperatures = new Mock<ISevenDayTemperatures>();
            _mockSevenDayTemperatures.Setup(x => x.GetSevenDayTemperatures()).Returns(expectedTemperatures);

            _mockDaylightReport = new Mock<IDaylightReport>();
            _mockDaylightReport.Setup(x => x.GetDaylightReport()).Returns(expectedDaylightReport);

            var weatherForecast = new Query.WeatherForecast(_mockSevenDayTemperatures.Object, _mockDaylightReport.Object);
            _sevenDayForecast = weatherForecast.GetSevenDayForecast();
            _daylightReportForecast = weatherForecast.GetDaylightReportWeatherForecast();
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

        [Test]
        public void ThenTheDaylightReportRequestIsMade()
        {
            _mockDaylightReport.Verify(x => x.GetDaylightReport(), Times.AtLeast(1));
        }

        [Test]
        public void ThenTheOverallDaylightReportForecastIsCorrect()
        {
            Assert.That(_daylightReportForecast.OverallDaylightReport, Is.EqualTo(_expectedOverallDaylightReport));
        }
    }
}
