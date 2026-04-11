using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Testx.Models;

namespace Testx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClubsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs() => await _context.Clubs.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            return club == null ? NotFound() : club;
        }

        [HttpGet("{id}/total-value")]
        public async Task<ActionResult<decimal>> GetClubTotalValue(int id)
        {
            var exists = await _context.Clubs.AnyAsync(c => c.Id == id);
            if (!exists) return NotFound();

            var players = await _context.Players.Where(p => p.ClubId == id).ToListAsync();
            var totalValue = players.Sum(p => p.Price);

            return Ok(totalValue);
        }

        [HttpPost]
        public async Task<ActionResult<Club>> PostClub(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClub), new { id = club.Id }, club);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClub(int id, Club club)
        {
            if (id != club.Id) return BadRequest();
            _context.Entry(club).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null) return NotFound();
            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}