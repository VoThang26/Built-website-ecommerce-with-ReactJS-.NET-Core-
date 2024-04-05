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
    public class Varlant_OptionController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Varlant_OptionController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Varlant_Option
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Varlant_Option>>> GetVarlant_Options()
        {
            return await _context.Varlant_Options.ToListAsync();
        }

        // GET: api/Varlant_Option/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Varlant_Option>> GetVarlant_Option(Guid id)
        {
            var varlant_Option = await _context.Varlant_Options.FindAsync(id);

            if (varlant_Option == null)
            {
                return NotFound();
            }

            return varlant_Option;
        }

        // POST: api/Varlant_Option
        [HttpPost]
        public async Task<ActionResult<Varlant_Option>> PostVarlant_Option(Varlant_Option varlant_Option)
        {
            _context.Varlant_Options.Add(varlant_Option);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVarlant_Option), new { id = varlant_Option.id }, varlant_Option);
        }

        // PUT: api/Varlant_Option/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVarlant_Option(Guid id, Varlant_Option varlant_Option)
        {
            if (id != varlant_Option.id)
            {
                return BadRequest();
            }

            _context.Entry(varlant_Option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Varlant_OptionExists(id))
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

        // DELETE: api/Varlant_Option/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVarlant_Option(Guid id)
        {
            var varlant_Option = await _context.Varlant_Options.FindAsync(id);
            if (varlant_Option == null)
            {
                return NotFound();
            }

            _context.Varlant_Options.Remove(varlant_Option);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Varlant_OptionExists(Guid id)
        {
            return _context.Varlant_Options.Any(e => e.id == id);
        }
    }
}
