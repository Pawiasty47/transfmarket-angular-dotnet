namespace Testx.Models
{
    public class PlayerDto
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

        public string FlagUrl { get; set; } = string.Empty;
    }
}