using Microsoft.EntityFrameworkCore;
using Testx.Models;

namespace Testx
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //dodaje dane do bazy danych przy jej tworzeniu, prosty seeder
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Nationality>().HasData(
                new Nationality { Id = 1, Name = "Polska", Trophies = 0 },
                new Nationality { Id = 2, Name = "Hiszpania", Trophies = 4 },
                new Nationality { Id = 3, Name = "Brazylia", Trophies = 5 },
                new Nationality { Id = 4, Name = "Anglia", Trophies = 1 }
            );

            modelBuilder.Entity<Club>().HasData(
                new Club { Id = 1, Name = "Real Madryt", FoundationDate = new DateTime(1902, 3, 6), Trophies = 100 },
                new Club { Id = 2, Name = "FC Barcelona", FoundationDate = new DateTime(1899, 11, 29), Trophies = 95 },
                new Club { Id = 3, Name = "Jagiellonia Białystok", FoundationDate = new DateTime(1920, 5, 20), Trophies = 2 }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, FirstName = "Robert", LastName = "Lewandowski", Age = 35, Weight = 81, Price = 15.0m, Position = "Napastnik", ClubId = 2, NationalityId = 1 },
                new Player { Id = 2, FirstName = "Vinicius", LastName = "Junior", Age = 23, Weight = 73, Price = 180.0m, Position = "Napastnik", ClubId = 1, NationalityId = 3 },
                new Player { Id = 3, FirstName = "Jude", LastName = "Bellingham", Age = 20, Weight = 75, Price = 180.0m, Position = "Pomocnik", ClubId = 1, NationalityId = 4 },
                new Player { Id = 4, FirstName = "Pedri", LastName = "Gonzalez", Age = 21, Weight = 60, Price = 90.0m, Position = "Pomocnik", ClubId = 2, NationalityId = 2 },
                new Player { Id = 5, FirstName = "Rodrygo", LastName = "Goes", Age = 23, Weight = 64, Price = 100.0m, Position = "Napastnik", ClubId = 1, NationalityId = 3 },
                new Player { Id = 6, FirstName = "Wojciech", LastName = "Szczęsny", Age = 34, Weight = 90, Price = 10.0m, Position = "Bramkarz", ClubId = 2, NationalityId = 1 },
                new Player { Id = 7, FirstName = "Lamine", LastName = "Yamal", Age = 16, Weight = 65, Price = 60.0m, Position = "Napastnik", ClubId = 2, NationalityId = 2 },
                new Player { Id = 8, FirstName = "Taras", LastName = "Romanczuk", Age = 32, Weight = 80, Price = 2.0m, Position = "Pomocnik", ClubId = 3, NationalityId = 1 },
                new Player { Id = 9, FirstName = "Jesus", LastName = "Imaz", Age = 33, Weight = 70, Price = 1.5m, Position = "Napastnik", ClubId = 3, NationalityId = 2 },
                new Player { Id = 10, FirstName = "Endrick", LastName = "Felipe", Age = 17, Weight = 72, Price = 45.0m, Position = "Napastnik", ClubId = 1, NationalityId = 3 },
                new Player { Id = 11, FirstName = "Gavi", LastName = "Paez", Age = 19, Weight = 68, Price = 90.0m, Position = "Pomocnik", ClubId = 2, NationalityId = 2 },
                new Player { Id = 12, FirstName = "Bartłomiej", LastName = "Wdowik", Age = 23, Weight = 74, Price = 3.0m, Position = "Obrońca", ClubId = 3, NationalityId = 1 },
                new Player { Id = 13, FirstName = "Fermin", LastName = "Lopez", Age = 20, Weight = 66, Price = 20.0m, Position = "Pomocnik", ClubId = 2, NationalityId = 2 },
                new Player { Id = 14, FirstName = "Eder", LastName = "Militao", Age = 26, Weight = 79, Price = 70.0m, Position = "Obrońca", ClubId = 1, NationalityId = 3 },
                new Player { Id = 15, FirstName = "Harry", LastName = "Kane", Age = 30, Weight = 86, Price = 110.0m, Position = "Napastnik", ClubId = 1, NationalityId = 4 }

            );
        }
    }
}