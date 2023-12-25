using System.Text.Json;
using WeatherAPI.Data.Repositories;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey;
        private readonly WeatherRepository _weatherRepository;
        public WeatherService(
            IHttpClientFactory httpClientFactory, 
            string apiKey, 
            WeatherRepository weatherRepository)
        {
            _httpClientFactory = httpClientFactory;
            _apiKey = apiKey;
            _weatherRepository = weatherRepository;
        }

        public async Task<WeatherResponse> GetWeatherByCoordinatesAsync(double lat, double lon)
        {
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={_apiKey}&units=metric";

            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                try
                {
                    Console.WriteLine($"WEATHER JSON: {jsonString}");

                    var weatherData = JsonSerializer.Deserialize<WeatherResponse>(jsonString,
                        new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });

                    await SaveWeatherAsync(weatherData);

                    return weatherData;

                }
                catch (Exception ex)
                {
                    throw new HttpRequestException($"Error en la deserializacion: {ex.Message}");
                }

            }
            else
            {
                throw new HttpRequestException($"Error al recuperar informacion del clima. Status code: {response.StatusCode}");
            }
        }

        public async Task SaveWeatherAsync(WeatherResponse weatherData)
        {
            try
            {
                await _weatherRepository.AddWeatherAsync(weatherData);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar datos del clima: {ex.Message}");
            }
        }

    }
}
