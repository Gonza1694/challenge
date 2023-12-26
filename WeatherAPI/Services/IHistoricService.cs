using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public interface IHistoricService
    {
        Task<IEnumerable<WeatherHistoric>> GetHistoricWeatherAsync(string city);
    }
}
