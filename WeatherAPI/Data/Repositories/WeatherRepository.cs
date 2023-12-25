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
                City = weatherData.Name,
                Temperature = weatherData.Main.Temp,
                Feels_Like = weatherData.Main.Feels_Like,
                Timestamp = DateTime.UtcNow
            };

            _dbContext.WeatherHistorics.Add(historicData);
            await _dbContext.SaveChangesAsync();
        }
    }
}
