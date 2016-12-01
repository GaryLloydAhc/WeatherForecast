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

            var sevenDayForecast = new SevenDayForecast
            {
                Temperatures = sevenDayTemperatures,
                AverageTemperature = sevenDayTemperatures.Sum() / 7
            };

            return sevenDayForecast;
        }

        public SevenDayForecast GetDaylightReportWeatherForecast()
        {
            SevenDayForecast overallDaylightReport;
            var cloudycount = _daylightReportTempsQuery.GetDaylightReport().Count(e => e == "Cloudy");
            var sunnycount = _daylightReportTempsQuery.GetDaylightReport().Count(e => e == "Sunny");
            if (sunnycount > cloudycount)
            {
                overallDaylightReport = new SevenDayForecast
                {
                    OverallDaylightReport = "Mostly Sunny"
                };
            }
            else
            {
                overallDaylightReport = new SevenDayForecast
                {
                    OverallDaylightReport = "Mostly Cloudy"
                };
            }

            return overallDaylightReport;

        }
    }
}