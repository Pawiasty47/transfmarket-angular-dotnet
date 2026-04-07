using System.Numerics;

namespace Testx.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime FoundationDate { get; set; }
        public int Trophies { get; set; }

        // Relacja: 1 Klub ma wielu piłkarzy
        public ICollection<Player>? Players { get; set; }
    }
}