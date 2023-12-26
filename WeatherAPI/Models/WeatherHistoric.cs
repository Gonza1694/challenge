namespace WeatherAPI.Models
{
    public class WeatherHistoric
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public double Temperature { get; set; }
        public double Feels_Like { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
