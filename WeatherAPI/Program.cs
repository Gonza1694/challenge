using WeatherAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IGeocodingService, GeocodingService>(provider =>
{
    var apiKey = "56025b0ebe4fbe40a1e325304e2669ef";
    return new GeocodingService(provider.GetRequiredService<IHttpClientFactory>(), apiKey);
});

builder.Services.AddScoped<IWeatherService, WeatherService>(provider =>
{
    var apiKey = "56025b0ebe4fbe40a1e325304e2669ef";
    return new WeatherService(provider.GetRequiredService<IHttpClientFactory>(), apiKey);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
