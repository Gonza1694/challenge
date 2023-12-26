using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WeatherAPI.Data;
using WeatherAPI.Models;
using WeatherAPI.Utils;

public class DbTests
{
    [Fact]
    public void EnsureDatabaseCanConnect()
    {
        var options = new DbContextOptionsBuilder<WeatherDbContext>()
            .UseSqlServer(ConnectionString.GetSQLString)
            .Options;

        using (var context = new WeatherDbContext(options))
        {
            context.Database.OpenConnection();
            try
            {
                context.Database.EnsureCreated();
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
    }

    [Fact]
    public void EnsureWeatherHistoricTableExists()
    {
        var options = new DbContextOptionsBuilder<WeatherDbContext>()
            .UseSqlServer(ConnectionString.GetSQLString)
            .Options;

        using (var context = new WeatherDbContext(options))
        {
            context.Database.EnsureCreated();

            var tableExists = context.Model.GetEntityTypes()
                .Any(e => e.ClrType == typeof(WeatherHistoric));

            Assert.True(tableExists, "La tabla WeatherHistoric no existe en el modelo de la base de datos");
        }
    }

    [Fact]
    public void EnsureWeatherHistoricTableHasCorrectColumns()
    {
        var options = new DbContextOptionsBuilder<WeatherDbContext>()
            .UseSqlServer(ConnectionString.GetSQLString)
            .Options;

        using (var context = new WeatherDbContext(options))
        {
            context.Database.EnsureCreated();

            var weatherHistoricEntityType = context.Model.FindEntityType(typeof(WeatherHistoric));

            Assert.NotNull(weatherHistoricEntityType);

            AssertPropertyExists(weatherHistoricEntityType, nameof(WeatherHistoric.Id));
            AssertPropertyExists(weatherHistoricEntityType, nameof(WeatherHistoric.Country));
            AssertPropertyExists(weatherHistoricEntityType, nameof(WeatherHistoric.City));
            AssertPropertyExists(weatherHistoricEntityType, nameof(WeatherHistoric.Temperature));
            AssertPropertyExists(weatherHistoricEntityType, nameof(WeatherHistoric.Feels_Like));
            AssertPropertyExists(weatherHistoricEntityType, nameof(WeatherHistoric.Timestamp));
        }
    }

    private void AssertPropertyExists(IEntityType entityType, string propertyName)
    {
        var property = entityType.FindProperty(propertyName);
        Assert.NotNull(property);
        Assert.Equal(propertyName, property.Name);
    }
}

