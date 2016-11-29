using WeatherForecast.Model;

namespace WeatherForecast.Query
{
    public interface IWeatherForecast
    {
        SevenDayForecast GetSeventDayForecast();
    }
}