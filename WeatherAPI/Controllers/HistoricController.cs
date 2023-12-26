using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Services;

[ApiController]
[Route("[controller]")]
public class HistoricController : ControllerBase
{
    private readonly IHistoricService _historicService;

    public HistoricController(IHistoricService historicService)
    {
        _historicService = historicService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHistoricWeather(string city)
    {
        try
        {
            var historicWeather = await _historicService.GetHistoricWeatherAsync(city);
            return Ok(historicWeather);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}
