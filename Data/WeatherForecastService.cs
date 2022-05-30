namespace Weather.Data
{
    public class WeatherForecastService
    {
        public async Task<List<WeatherForecast>> GetForecastAsync(DateTime startDate)
        {
            HttpClient cl = new HttpClient() { BaseAddress = new Uri("http://api.weatherapi.com") };
            var response = await cl.GetFromJsonAsync<Root>("http://api.weatherapi.com/v1/forecast.json?key=3afc06db33e4405fae9210055222105&q=Tallinn&days=7");
            var output = new List<WeatherForecast>();

            foreach (var item in response.forecast.forecastday)
            {
                output.Add(new WeatherForecast()
                {
                    Date = DateTime.Parse(item.date),
                    TemperatureC = Convert.ToInt32(Math.Round(item.day.avgtemp_c, 0)),
                    Summary = item.day.condition.text,
                    ICON = item.day.condition.icon,
                    MaxWind = Convert.ToInt32(Math.Round(item.day.maxwind_kph, 0)),
                    RainChance = item.day.daily_chance_of_rain,
                    SnowChance = item.day.daily_chance_of_snow
                });
            }
            return output;
        }
    }
}
public class Root
{
    public WeatherLocation location { get; set; }
    public Current current { get; set; }
    public Forecast forecast { get; set; }
}
public class Condition
{
    public string text { get; set; }
    public string icon { get; set; }
}

public class Current
{
    public double temp_c { get; set; }
    public Condition condition { get; set; }
    public double wind_kph { get; set; }
    public double feelslike_c { get; set; }
    
}

public class Day
{
    public double avgtemp_c { get; set; }
    public double maxwind_kph { get; set; }
    public int daily_chance_of_rain { get; set; }
    public int daily_chance_of_snow { get; set; }
    public Condition condition { get; set; }
}

public class Forecast
{
    public List<Forecastday> forecastday { get; set; }
}

public class Forecastday
{
    public string date { get; set; }
    public Day day { get; set; }
    
}

public class WeatherLocation
{
    public string City { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string LocalTime { get; set; }
}




