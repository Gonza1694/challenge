using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data.Repositories;
using WeatherAPI.Models;

namespace WeatherAPI.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
        : base(options)
        {
        }

        public DbSet<WeatherHistoric> WeatherHistorics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
