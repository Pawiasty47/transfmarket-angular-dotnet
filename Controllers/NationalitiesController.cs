using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Testx.Models;

namespace Testx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NationalitiesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nationality>>> GetNationalities() => await _context.Nationalities.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Nationality>> GetNationality(int id)
        {
            var nationality = await _context.Nationalities.FindAsync(id);
            return nationality == null ? NotFound() : nationality;
        }

        [HttpGet("{id}/total-value")]
        public async Task<ActionResult<decimal>> GetNationalityTotalValue(int id)
        {
            var exists = await _context.Nationalities.AnyAsync(n => n.Id == id);
            if (!exists) return NotFound();

            // ZMIANA: To samo dla narodowości
            var players = await _context.Players.Where(p => p.NationalityId == id).ToListAsync();
            var totalValue = players.Sum(p => p.Price);

            return Ok(totalValue);
        }

        [HttpPost]
        public async Task<ActionResult<Nationality>> PostNationality(Nationality nationality)
        {
            _context.Nationalities.Add(nationality);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNationality), new { id = nationality.Id }, nationality);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNationality(int id)
        {
            var nationality = await _context.Nationalities.FindAsync(id);
            if (nationality == null) return NotFound();
            _context.Nationalities.Remove(nationality);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}