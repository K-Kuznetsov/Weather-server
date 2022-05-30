namespace Weather.Data
{
    public class CurrentWeatherService
    {
        public async Task<List<CurrentWeather>> GetCurrentAsync(DateTime startDate)
        {
            HttpClient cl2 = new HttpClient() { BaseAddress = new Uri("http://api.weatherapi.com") };
            var response = await cl2.GetFromJsonAsync<Root>("http://api.weatherapi.com/v1/forecast.json?key=3afc06db33e4405fae9210055222105&q=Tallinn&days=7");
            var output = new List<CurrentWeather>();

            foreach (var item in response.current)
            {
                output.Add(new CurrentWeather()
                {
                    
                });
            }
            return output;
        }
    }
    public class Root
    {
        public WeatherLocation location { get; set; }
        public CurrentWeather current { get; set; }
        public Forecast forecast { get; set; }
    }
    public class Condition
    {
        public string text { get; set; }
        public string icon { get; set; }
    }

    public class CurrentWeather
    {
        public double CurrTemp { get; set; }
        public CurrCondition CurrCondition { get; set; }
        public double CurrWind { get; set; }
        public double FeelsLike { get; set; }
    }
}
