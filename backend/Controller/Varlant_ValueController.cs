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
    public class Varlant_ValueController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Varlant_ValueController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Varlant_Value
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Varlant_Value>>> GetVarlant_Values()
        {
            return await _context.Varlant_Values.ToListAsync();
        }

        // GET: api/Varlant_Value/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Varlant_Value>> GetVarlant_Value(Guid id)
        {
            var varlant_Value = await _context.Varlant_Values.FindAsync(id);

            if (varlant_Value == null)
            {
                return NotFound();
            }

            return varlant_Value;
        }

        // POST: api/Varlant_Value
        [HttpPost]
        public async Task<ActionResult<Varlant_Value>> PostVarlant_Value(Varlant_Value varlant_Value)
        {
            _context.Varlant_Values.Add(varlant_Value);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVarlant_Value), new { id = varlant_Value.id }, varlant_Value);
        }

        // PUT: api/Varlant_Value/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVarlant_Value(Guid id, Varlant_Value varlant_Value)
        {
            if (id != varlant_Value.id)
            {
                return BadRequest();
            }

            _context.Entry(varlant_Value).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Varlant_ValueExists(id))
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

        // DELETE: api/Varlant_Value/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVarlant_Value(Guid id)
        {
            var varlant_Value = await _context.Varlant_Values.FindAsync(id);
            if (varlant_Value == null)
            {
                return NotFound();
            }

            _context.Varlant_Values.Remove(varlant_Value);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Varlant_ValueExists(Guid id)
        {
            return _context.Varlant_Values.Any(e => e.id == id);
        }
    }
}
