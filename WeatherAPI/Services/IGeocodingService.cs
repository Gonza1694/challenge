using static GeocodingService;

namespace WeatherAPI.Services
{
    public interface IGeocodingService
    {
        Task<GeocodingResponse> GetCityCoordinates(string cityName);
    }
}