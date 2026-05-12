using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Testx.Models;
using Testx.Services;

namespace Testx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase //dziedziczenie po klasie controllerbase do obslugi zadan pakietow http
    {
        private readonly AppDbContext _context;
        private readonly ICountryApiService _countryApiService; //api do flag

        //pobranie bazy danych i api od flag
        public PlayersController(AppDbContext context, ICountryApiService countryApiService) //dependency injection
        {
            _context = context;
            _countryApiService = countryApiService;
        }

        [HttpGet] //pelna lista zawodnikow z async, z opcjonalnymi parametrami do filtrowania po klubie i narodowosci
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers([FromQuery] int? clubId, [FromQuery] int? nationalityId) //interfejs enumerable zeby zwrocic kolekcje obiektow PlaterDTO zeby moc zrobic foreach
            //Task metoda asynchroniczna ActionResult zwroci dane i kody status http
        {
            var query = _context.Players
                .Include(p => p.Club)
                .Include(p => p.Nationality)
                .AsQueryable();

            if (clubId.HasValue) query = query.Where(p => p.ClubId == clubId.Value);
            if (nationalityId.HasValue) query = query.Where(p => p.NationalityId == nationalityId.Value);

            var players = await query.ToListAsync();

            var uniqueCountries = players
                .Where(p => p.Nationality != null)
                .Select(p => p.Nationality!.Name)
                .Distinct()
                .ToList();

            var flagsDictionary = new Dictionary<string, string>();
            foreach (var country in uniqueCountries)
            {
                var flagUrl = await _countryApiService.GetFlagUrlAsync(country);
                flagsDictionary[country] = flagUrl;
            }

            var result = players.Select(p => new PlayerDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age,
                Weight = p.Weight,
                Price = p.Price,
                Position = p.Position,
                ClubName = p.Club?.Name ?? "Brak klubu", //we froncie jest walidacja ze trzeba podac ten klub i reprezentacje
                NationalityName = p.Nationality?.Name ?? "Brak narodu",

                FlagUrl = (p.Nationality != null && flagsDictionary.ContainsKey(p.Nationality.Name))
                            ? flagsDictionary[p.Nationality.Name]
                            : string.Empty
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")] //konkretny zawodnik po id, z informacjami o klubie i narodowosci
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players
                .Include(p => p.Club)
                .Include(p => p.Nationality)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (player == null) return NotFound();

            return player;
        }

        [HttpPost] //dodanie zawodnik
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

        [HttpPut("{id}")] //edycja zawodnika
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.Id) return BadRequest();

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); //w przypadku edycji zawodnika, który został usunięty przez innego użytkownika, wystąpi DbUpdateConcurrencyException, dlatego sprawdzamy czy zawodnik nadal istnieje
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Players.Any(e => e.Id == id)) return NotFound(); //zwraca blad http404 not found
                else throw;
            }

            return NoContent(); //eydcja sie powiodla http204
        }

        [HttpDelete("{id}")] //usuwanie zawodnika
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}