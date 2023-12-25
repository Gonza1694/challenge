using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Services;

[ApiController]
[Route("[controller]")]
public class GeocodingController : ControllerBase
{
    private readonly IGeocodingService _geocodingService;

    public GeocodingController(IGeocodingService geocodingService)
    {
        _geocodingService = geocodingService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult<object>> Get(string city)
    {
        try
        {
            var cityCoordinates = await _geocodingService.GetCityCoordinates(city);
            return Ok(cityCoordinates);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
}
