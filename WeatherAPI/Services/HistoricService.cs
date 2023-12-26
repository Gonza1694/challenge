using WeatherAPI.Data.Repositories;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class HistoricService : IHistoricService
    {
        private readonly WeatherRepository _weatherRepository;

        public HistoricService(WeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<IEnumerable<WeatherHistoric>> GetHistoricWeatherAsync(string city)
        {
            return await _weatherRepository.GetHistoricWeatherAsync(city);
        }
    }
}
