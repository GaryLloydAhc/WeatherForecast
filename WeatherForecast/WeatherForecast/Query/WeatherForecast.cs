using System.Linq;
using WeatherForecast.Model;

namespace WeatherForecast.Query
{
    public class WeatherForecast : IWeatherForecast
    {
        private readonly ISevenDayTemperatures _sevenDayTempsQuery;

        public WeatherForecast(ISevenDayTemperatures sevenDayTempsQuery)
        {
            _sevenDayTempsQuery = sevenDayTempsQuery;
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
    }
}