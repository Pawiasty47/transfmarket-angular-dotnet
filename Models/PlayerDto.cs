namespace Testx.Models
{
    public class PlayerDto //klasa DTO dla zawodnika, zawiera tylko te pola, ktore sa potrzebne do wyswietlenia na froncie, oraz dodatkowe pole z nazwa klubu i narodowosci, zamiast id, oraz pole z url do flagi narodowej
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public string Position { get; set; } = string.Empty;

        public string ClubName { get; set; } = string.Empty;
        public string NationalityName { get; set; } = string.Empty;

        public string FlagUrl { get; set; } = string.Empty; //pole z url do flagi narodowej, bedzie pobierane z zewnętrznego API na podstawie nazwy narodowości
    }
}