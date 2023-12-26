using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;

namespace WeatherAPI.Data.Repositories
{
    public class WeatherRepository
    {
        private readonly WeatherDbContext _dbContext;

        public WeatherRepository(WeatherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddWeatherAsync(WeatherResponse weatherData)
        {
            var historicData = new WeatherHistoric
            {
                Country = weatherData.Sys.Country,
                City = weatherData.Name,
                Temperature = weatherData.Main.Temp,
                Feels_Like = weatherData.Main.Feels_Like,
                Timestamp = DateTime.UtcNow
            };

            _dbContext.WeatherHistorics.Add(historicData);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<WeatherHistoric>> GetHistoricWeatherAsync(string city)
        {
            var historicWeather = await _dbContext.WeatherHistorics
                .Where(h => h.City == city)
                .OrderByDescending(h => h.Timestamp)
                .Take(10)
                .ToListAsync();

            return historicWeather;
        }
    }
}
