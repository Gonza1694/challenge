using System.Text.Json;
using WeatherAPI.Services;

public class GeocodingService : IGeocodingService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;

    public GeocodingService(IHttpClientFactory httpClientFactory, string apiKey)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = apiKey;
    }

    public async Task<GeocodingResponse> GetCityCoordinates(string cityName)
    {
        string apiUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=5&appid={_apiKey}";

        var httpClient = _httpClientFactory.CreateClient();

        var response = await httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string country = "AR";
            var jsonString = await response.Content.ReadAsStringAsync();

            try
            {
                Console.WriteLine($"GEOCODING JSON: {jsonString}");

                var cities = JsonSerializer.Deserialize<List<GeocodingResponse>>(jsonString,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });

                var city = cities.FirstOrDefault(c => c.Country == country);

                if (city != null)
                {
                    return city;
                }
                else
                {
                    throw new HttpRequestException("No se encontraron coordenadas.");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Error en la deserializacion: {ex.Message}");
            }
        }
        else
        {
            throw new HttpRequestException($"Error al recuperar las coordenadas. Status code: {response.StatusCode}");
        }
    }

    public class GeocodingResponse
    {
        public string Name { get; set; }
        public double Lat{ get; set; }
        public double Lon{ get; set; }
        public string Country { get; set; }
    }

}
