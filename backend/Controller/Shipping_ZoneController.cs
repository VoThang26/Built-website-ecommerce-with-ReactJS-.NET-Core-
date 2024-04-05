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
    public class Shipping_ZoneController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Shipping_ZoneController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Shipping_Zone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping_Zone>>> GetShipping_Zones()
        {
            return await _context.Shipping_Zones.ToListAsync();
        }

        // GET: api/Shipping_Zone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping_Zone>> GetShipping_Zone(int id)
        {
            var shipping_Zone = await _context.Shipping_Zones.FindAsync(id);

            if (shipping_Zone == null)
            {
                return NotFound();
            }

            return shipping_Zone;
        }

        // POST: api/Shipping_Zone
        [HttpPost]
        public async Task<ActionResult<Shipping_Zone>> PostShipping_Zone(Shipping_Zone shipping_Zone)
        {
            _context.Shipping_Zones.Add(shipping_Zone);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShipping_Zone), new { id = shipping_Zone.id }, shipping_Zone);
        }

        // PUT: api/Shipping_Zone/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping_Zone(int id, Shipping_Zone shipping_Zone)
        {
            if (id != shipping_Zone.id)
            {
                return BadRequest();
            }

            _context.Entry(shipping_Zone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Shipping_ZoneExists(id))
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

        // DELETE: api/Shipping_Zone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping_Zone(int id)
        {
            var shipping_Zone = await _context.Shipping_Zones.FindAsync(id);
            if (shipping_Zone == null)
            {
                return NotFound();
            }

            _context.Shipping_Zones.Remove(shipping_Zone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Shipping_ZoneExists(int id)
        {
            return _context.Shipping_Zones.Any(e => e.id == id);
        }
    }
}
