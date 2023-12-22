using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Services;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IGeocodingService _geocodingService;
    private readonly IWeatherService _weatherService;

    public WeatherController(IGeocodingService geocodingService, IWeatherService weatherService)
    {
        _geocodingService = geocodingService;
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeatherByCityAsync()
    {
        var city = "Buenos Aires";

        try
        {
            var cityCoordinates = await _geocodingService.GetCityCoordinates(city);

            var weatherData = await _weatherService.GetWeatherByCoordinatesAsync(cityCoordinates.Lat, cityCoordinates.Lon);

            return Ok(weatherData);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}
