using System.Numerics;

namespace Testx.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Trophies { get; set; } // Ilość trofeów narodowych

        // Relacja: 1 Narodowość ma wielu piłkarzy
        public ICollection<Player>? Players { get; set; }
    }
}