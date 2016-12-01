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
            var daylightReport = forecast.GetDaylightReportWeatherForecast();
            Console.WriteLine($"Average temperature for the next 7 days is {sevenDayForecast.AverageTemperature}");
            Console.WriteLine($"Overall daylight report for the next 7 days is {daylightReport.OverallDaylightReport}");
            Console.ReadKey();
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
