namespace WeatherForecast.Query
{
    public class SevenDayTemperatures : ISevenDayTemperatures
    {
        public int[] GetSevenDayTemperatures()
        {
            // This would normally get the temperatures from a database or service
            return new int[] { 17, 15, 14, 18, 20, 22, 19 };
        }
    }
}