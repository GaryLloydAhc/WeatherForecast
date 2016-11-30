using System;
using StructureMap;
using WeatherForecast.Query;

namespace WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = InitialiseDependencyInjection();
            var forecast = container.TryGetInstance<IWeatherForecast>();
            var sevenDayForecast = forecast.GetSevenDayForecast();
            Console.WriteLine($"Average temperature for the next 7 days is {sevenDayForecast.AverageTemperature}");
        }

        private static Container InitialiseDependencyInjection()
        {
            return new Container(c =>
            {
                c.Scan(x => {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
            });
        }
    }
}
