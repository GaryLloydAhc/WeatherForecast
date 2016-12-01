namespace WeatherForecast.Query
{
    public class DaylightReport : IDaylightReport
    {      
        public string[] GetDaylightReport()
        {
            return new string[] { "Cloudy", "Sunny", "Cloudy", "Cloudy", "Sunny", "Sunny", "Sunny" };
        }
    }
}
