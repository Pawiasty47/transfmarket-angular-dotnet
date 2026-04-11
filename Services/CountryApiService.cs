using System.Text.Json;

namespace Testx.Services
{
    public interface ICountryApiService //interfejs api do flag
    {
        Task<string> GetFlagUrlAsync(string countryName);
    }

    public class CountryApiService : ICountryApiService //klasa implementujaca api do flag, korzysta z HttpClient do pobierania danych z zewnętrznego API restcountries.com, i zwraca url do flagi narodowej na podstawie nazwy kraju, z dodatkowym mapperem dla Anglii, ktora jest wyszukiwana jako United Kingdom, oraz obsluga bledow i zwracanie pustego stringa w przypadku niepowodzenia
    {
        private readonly HttpClient _httpClient;

        public CountryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetFlagUrlAsync(string countryName) //metoda do pobierania url do flagi narodowej na podstawie nazwy kraju
        {
            var countryMapper = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "Anglia", "United Kingdom" } //mapper dla Anglii, bo restcountries.com szuka jej jako United Kingdom, a w bazie mamy Anglia
    };

            var searchName = countryMapper.ContainsKey(countryName) ? countryMapper[countryName] : countryName;

            try
            {
                var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/translation/{searchName}"); //najpierw probujemy szukac po nazwie przetlumaczonej, bo restcountries.com ma endpoint do szukania po nazwie przetlumaczonej, ale nie zawsze dziala, dlatego mamy fallback do szukania po nazwie oryginalnej

                if (!response.IsSuccessStatusCode)
                {
                    response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{searchName}"); //fallback do szukania po nazwie oryginalnej
                    if (!response.IsSuccessStatusCode) return string.Empty;
                }

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