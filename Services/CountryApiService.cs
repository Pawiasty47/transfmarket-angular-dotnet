using System.Text.Json;

namespace Testx.Services
{
    public interface ICountryApiService
    {
        Task<string> GetFlagUrlAsync(string countryName);
    }

    public class CountryApiService : ICountryApiService
    {
        private readonly HttpClient _httpClient;

        public CountryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetFlagUrlAsync(string countryName)
        {
            try
            {

                var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{countryName}");

                if (!response.IsSuccessStatusCode) return string.Empty;

                var jsonString = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(jsonString);
                var root = doc.RootElement[0];

                if (root.TryGetProperty("flags", out var flags) && flags.TryGetProperty("svg", out var flagUrl))
                {
                    return flagUrl.GetString() ?? string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return string.Empty;
        }
    }
}