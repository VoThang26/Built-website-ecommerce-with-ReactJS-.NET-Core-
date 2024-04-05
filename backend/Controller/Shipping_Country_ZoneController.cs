using vohoangthang.Exercise02.Context;
using vohoangthang.Exercise02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vohoangthang.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Shipping_Country_ZoneController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Shipping_Country_ZoneController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Shipping_Country_Zone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping_Country_Zone>>> GetShipping_Country_Zones()
        {
            return await _context.Shipping_Country_Zones.ToListAsync();
        }

        // GET: api/Shipping_Country_Zone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping_Country_Zone>> GetShipping_Country_Zone(Guid id)
        {
            var shipping_Country_Zone = await _context.Shipping_Country_Zones.FindAsync(id);

            if (shipping_Country_Zone == null)
            {
                return NotFound();
            }

            return shipping_Country_Zone;
        }

        // POST: api/Shipping_Country_Zone
        [HttpPost]
        public async Task<ActionResult<Shipping_Country_Zone>> PostShipping_Country_Zone(Shipping_Country_Zone shipping_Country_Zone)
        {
            _context.Shipping_Country_Zones.Add(shipping_Country_Zone);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShipping_Country_Zone), new { id = shipping_Country_Zone.id }, shipping_Country_Zone);
        }

        // PUT: api/Shipping_Country_Zone/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping_Country_Zone(Guid id, Shipping_Country_Zone shipping_Country_Zone)
        {
            if (id != shipping_Country_Zone.id)
            {
                return BadRequest();
            }

            _context.Entry(shipping_Country_Zone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Shipping_Country_ZoneExists(id))
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

        // DELETE: api/Shipping_Country_Zone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping_Country_Zone(Guid id)
        {
            var shipping_Country_Zone = await _context.Shipping_Country_Zones.FindAsync(id);
            if (shipping_Country_Zone == null)
            {
                return NotFound();
            }

            _context.Shipping_Country_Zones.Remove(shipping_Country_Zone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Shipping_Country_ZoneExists(Guid id)
        {
            return _context.Shipping_Country_Zones.Any(e => e.id == id);
        }
    }
}
