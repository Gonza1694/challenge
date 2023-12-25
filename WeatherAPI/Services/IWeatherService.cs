using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherByCoordinatesAsync(double lat, double lon);
    }
}
