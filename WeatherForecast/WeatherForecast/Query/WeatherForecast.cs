using System.Linq;
using WeatherForecast.Model;

namespace WeatherForecast.Query
{
    public class WeatherForecast : IWeatherForecast
    {
        private readonly ISevenDayTemperatures _sevenDayTempsQuery;
        private readonly IDaylightReport _daylightReportTempsQuery;
        public WeatherForecast(ISevenDayTemperatures sevenDayTempsQuery, IDaylightReport daylightReportTempsQuery)
        {
            _sevenDayTempsQuery = sevenDayTempsQuery;
            _daylightReportTempsQuery = daylightReportTempsQuery;
        }

        public SevenDayForecast GetSevenDayForecast()
        {
            var sevenDayTemperatures = _sevenDayTempsQuery.GetSevenDayTemperatures();
            var daylightReport = _daylightReportTempsQuery.GetDaylightReport();
            var overallDaylightReportForecast = "Mostly " + (daylightReport.Count(e => e == "Sunny") > daylightReport.Count(e => e == "Cloudy") ? "Sunny" : "Cloudy");

            var sevenDayForecast = new SevenDayForecast
            {
                Temperatures = sevenDayTemperatures,
                AverageTemperature = sevenDayTemperatures.Sum() / 7,
                DaylightReport = daylightReport,
                OverallDaylightReport = overallDaylightReportForecast
            };

            return sevenDayForecast;
        }
    }
}