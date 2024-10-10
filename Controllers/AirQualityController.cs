using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QualityMonitoring.Data.Contexts;
using QualityMonitoring.Models;

namespace QualityMonitoring.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirQualityController : ControllerBase
    {

        private readonly DatabaseContext _context;

        public AirQualityController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AirQuality
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirQuality>>> GetAirQuality()
        {
            return await _context.AirQuality.ToListAsync();
        }

        // GET: api/AirQuality/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirQuality>> GetAirQuality(int id)
        {
            var airQuality = await _context.AirQuality.FindAsync(id);

            if (airQuality == null)
            {
                return NotFound();
            }

            return airQuality;
        }

        // PUT: api/AirQuality/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirQuality(int id, AirQuality airQuality)
        {
            if (id != airQuality.Id)
            {
                return BadRequest();
            }

            _context.Entry(airQuality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirQualityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AirQuality
        [HttpPost]
        public async Task<ActionResult<AirQuality>> PostAirQuality(AirQuality airQuality)
        {
            _context.AirQuality.Add(airQuality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirQuality", new { id = airQuality.Id }, airQuality);
        }

        // DELETE: api/AirQuality/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirQuality(int id)
        {
            var airQuality = await _context.AirQuality.FindAsync(id);
            if (airQuality == null)
            {
                return NotFound();
            }

            _context.AirQuality.Remove(airQuality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirQualityExists(int id)
        {
            return _context.AirQuality.Any(e => e.Id == id);
        }
    }
}

    



