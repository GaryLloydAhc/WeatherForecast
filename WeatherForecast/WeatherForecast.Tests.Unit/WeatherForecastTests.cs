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
        private int _expectedAvgTemperature;
        private string _expectedOverallDaylightReport;
        private int[] _expectedTemperatures;
        private string[] _expectedDaylightReport;


        [OneTimeSetUp]
        public void GivenAWeatherForecast_WhenASevenDayForecastIsRequested()
        {
            _expectedTemperatures = new [] { 12, 13, 10, 8, 26, 27, 19 };
            _expectedAvgTemperature = _expectedTemperatures.Sum() / 7;

            _expectedDaylightReport = new[] {"Cloudy", "Sunny", "Cloudy", "Cloudy", "Sunny", "Sunny", "Sunny"};
            _expectedOverallDaylightReport = "Mostly Sunny";

            _mockSevenDayTemperatures = new Mock<ISevenDayTemperatures>();
            _mockSevenDayTemperatures.Setup(x => x.GetSevenDayTemperatures()).Returns(_expectedTemperatures);

            _mockDaylightReport = new Mock<IDaylightReport>();
            _mockDaylightReport.Setup(x => x.GetDaylightReport()).Returns(_expectedDaylightReport);

            var weatherForecast = new Query.WeatherForecast(_mockSevenDayTemperatures.Object, _mockDaylightReport.Object);
            _sevenDayForecast = weatherForecast.GetSevenDayForecast();
        }

        [Test]
        public void ThenTheSevenDayTemperatureRequestIsMade()
        {
            _mockSevenDayTemperatures.Verify(x => x.GetSevenDayTemperatures(), Times.Once);
        }

        [Test]
        public void ThenTheSevenDayTemperaturesAreCorrect()
        {
            var temperaturesAreEqual = _sevenDayForecast.Temperatures.SequenceEqual(_expectedTemperatures);
            Assert.That(temperaturesAreEqual);
        }

        [Test]
        public void ThenTheAverageTemperatureIsCorrect()
        {
            Assert.That(_sevenDayForecast.AverageTemperature, Is.EqualTo(_expectedAvgTemperature));
        }

        [Test]
        public void ThenTheDaylightReportRequestIsMade()
        {
            _mockDaylightReport.Verify(x => x.GetDaylightReport(), Times.Once);
        }

        [Test]
        public void ThenTheSevenDayDaylightReportIsCorrect()
        {
            var daylightReportsAreEqual = _sevenDayForecast.DaylightReport.SequenceEqual(_expectedDaylightReport);
            Assert.That(daylightReportsAreEqual);
        }

        [Test]
        public void ThenTheOverallDaylightReportForecastIsCorrect()
        {
            Assert.That(_sevenDayForecast.OverallDaylightReport, Is.EqualTo(_expectedOverallDaylightReport));
        }
    }
}
