namespace Testx.Models
{
    public class Player //klasa zawodnika
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public double Weight { get; set; }

        public decimal Price { get; set; }
        public string Position { get; set; } = string.Empty; 

        public int ClubId { get; set; } //klucz obcy do klubu
        public Club? Club { get; set; }

        public int NationalityId { get; set; } //klucz obcy do narodowości
        public Nationality? Nationality { get; set; }
    }
}