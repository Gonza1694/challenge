using WeatherAPI.Services;

namespace WeatherAPI.Models
{
    public class WeatherResponse
    {
        public Main Main { get; set; }
        public Sys Sys { get; set; }
        public string Name { get; set; }
    }
    public class Sys
    {
        public string Country { get; set; }
    }
    public class Main
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
    }
}
