using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QualityMonitoring.Data.Contexts;
using QualityMonitoring.Models;

namespace QualityMonitoring.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaterQualityController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WaterQualityController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/WaterQuality
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterQuality>>> GetWaterQualities()
        {
            return await _context.WaterQualities.ToListAsync();
        }

        // GET: api/WaterQuality/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterQuality>> GetWaterQuality(int id)
        {
            var waterQuality = await _context.WaterQualities.FindAsync(id);

            if (waterQuality == null)
            {
                return NotFound();
            }

            return waterQuality;
        }

        // PUT: api/WaterQuality/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterQuality(int id, WaterQuality waterQuality)
        {
            if (id != waterQuality.Id)
            {
                return BadRequest();
            }

            _context.Entry(waterQuality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterQualityExists(id))
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

        // POST: api/WaterQuality
        [HttpPost]
        public async Task<ActionResult<WaterQuality>> PostWaterQuality(WaterQuality waterQuality)
        {
            _context.WaterQualities.Add(waterQuality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterQuality", new { id = waterQuality.Id }, waterQuality);
        }

        // DELETE: api/WaterQuality/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaterQuality(int id)
        {
            var waterQuality = await _context.WaterQualities.FindAsync(id);
            if (waterQuality == null)
            {
                return NotFound();
            }

            _context.WaterQualities.Remove(waterQuality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WaterQualityExists(int id)
        {
            return _context.WaterQualities.Any(e => e.Id == id);
        }
    }

}


