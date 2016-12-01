namespace WeatherForecast.Model
{
    public class SevenDayForecast
    {
        public int[] Temperatures { get; set; }
        public int AverageTemperature { get; set; }
        public string[] DaylightReport { get; set; }
        public string OverallDaylightReport { get; set; }
    }
}