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
    public class VarlantController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public VarlantController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Varlant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Varlant>>> GetVarlants()
        {
            return await _context.Varlants.ToListAsync();
        }

        // GET: api/Varlant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Varlant>> GetVarlant(Guid id)
        {
            var varlant = await _context.Varlants.FindAsync(id);

            if (varlant == null)
            {
                return NotFound();
            }

            return varlant;
        }

        // POST: api/Varlant
        [HttpPost]
        public async Task<ActionResult<Varlant>> PostVarlant(Varlant varlant)
        {
            _context.Varlants.Add(varlant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVarlant), new { id = varlant.id }, varlant);
        }

        // PUT: api/Varlant/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVarlant(Guid id, Varlant varlant)
        {
            if (id != varlant.id)
            {
                return BadRequest();
            }

            _context.Entry(varlant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VarlantExists(id))
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

        // DELETE: api/Varlant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVarlant(Guid id)
        {
            var varlant = await _context.Varlants.FindAsync(id);
            if (varlant == null)
            {
                return NotFound();
            }

            _context.Varlants.Remove(varlant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VarlantExists(Guid id)
        {
            return _context.Varlants.Any(e => e.id == id);
        }
    }
}
