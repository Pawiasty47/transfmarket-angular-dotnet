namespace Testx.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public double Weight { get; set; }

        public decimal Price { get; set; }
        public string Position { get; set; } = string.Empty; 

        public int ClubId { get; set; }
        public Club? Club { get; set; }

        public int NationalityId { get; set; }
        public Nationality? Nationality { get; set; }
    }
}