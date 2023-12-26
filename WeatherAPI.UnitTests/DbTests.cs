using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;
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

}
