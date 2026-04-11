namespace Testx.Models
{
    public class NbpResponse
    {
        public List<NbpRate> Rates { get; set; } = new(); //nbp zwraca liste kursow, ale my potrzebujemy tylko jeden, wiec bierzemy pierwszy element tej listy i jego pole Mid
    }

    public class NbpRate
    {
        public decimal Mid { get; set; } //pole Mid zawiera aktualny kurs wymiany dla danej waluty
    }
}