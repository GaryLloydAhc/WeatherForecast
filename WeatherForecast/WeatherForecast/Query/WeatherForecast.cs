using System.Linq;
using WeatherForecast.Model;

namespace WeatherForecast.Query
{
    public class WeatherForecast : IWeatherForecast
    {
        private readonly ISevenDayTemperatures _sevenDayTemperatureQuery;
        private readonly IDaylightReport _daylightReportQuery;
        public WeatherForecast(ISevenDayTemperatures sevenDayTemperatureQuery, IDaylightReport daylightReportQuery)
        {
            _sevenDayTemperatureQuery = sevenDayTemperatureQuery;
            _daylightReportQuery = daylightReportQuery;
        }

        public SevenDayForecast GetSevenDayForecast()
        {
            var sevenDayTemperatures = _sevenDayTemperatureQuery.GetSevenDayTemperatures();
            var daylightReport = _daylightReportQuery.GetDaylightReport();

            var sevenDayForecast = new SevenDayForecast
            {
                Temperatures = sevenDayTemperatures,
                AverageTemperature = sevenDayTemperatures.Sum() / 7,
                DaylightReport = daylightReport,
                OverallDaylightReport = GetOverallDaylightForecast(daylightReport)
            };

            return sevenDayForecast;
        }

        private static string GetOverallDaylightForecast(string[] daylightReport)
        {
            return daylightReport.Count(e => e == "Sunny") > daylightReport.Count(e => e == "Cloudy")
                       ? "Mostly Sunny"
                       : "Mostly Cloudy";
        }
    }
}