namespace Weather.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public double MaxWind { get; set; }
        public int Rainchance { get; set; }
        public int SnowChance { get; set; }
        public string Summary { get; set; }
        public string ICON { get; set; }

    }
}