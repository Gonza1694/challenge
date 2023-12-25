using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;
using WeatherAPI.Data.Repositories;
using WeatherAPI.Services;
using WeatherAPI.Utils;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string apiKey = "56025b0ebe4fbe40a1e325304e2669ef";

        builder.Services.AddDbContext<WeatherDbContext>(options =>
        {
            options.UseSqlServer(ConnectionString.GetSQLString);
        });

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowWeatherApp",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        builder.Services.AddHttpClient();

        builder.Services.AddScoped<WeatherRepository>();

        builder.Services.AddScoped<IGeocodingService, GeocodingService>(provider =>
        {
            return new GeocodingService(provider.GetRequiredService<IHttpClientFactory>(), apiKey);
        });

        builder.Services.AddScoped<IWeatherService, WeatherService>(provider =>
        {
            var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
            var weatherRepository = provider.GetRequiredService<WeatherRepository>();

            return new WeatherService(httpClientFactory, apiKey, weatherRepository);
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowWeatherApp");

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}