using Testx.Models;

namespace Testx.Services
{
    public class NbpService
    {
        private readonly HttpClient _httpClient;

        public NbpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetEurExchangeRateAsync() //metoda do pobierania kursu EUR z API NBP, zwraca kurs jako decimal, a w przypadku błędu zwraca domyślny kurs 4.30
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<NbpResponse>("https://api.nbp.pl/api/exchangerates/rates/a/eur/?format=json"); //zapytanie get i od razu zmapowanie go na klase nbpresponse

                return response?.Rates?.FirstOrDefault()?.Mid ?? 0m; //?. operacja przeszla jesli tak dalej, jesli wynik jest null ?? to zwroc 0m
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd pobierania kursu NBP: {ex.Message}"); //w przypadku braku zwroc bazowe 4.30
                return 4.30m;
            }
        }
    }
}