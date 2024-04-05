using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vohoangthang.Exercise02.Context;
using vohoangthang.Exercise02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace vohoangthang.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Attribute_ValueController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Attribute_ValueController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Attribute_Value
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attribute_Value>>> GetAttribute_Values()
        {
            return await _context.Attribute_Values.ToListAsync();
        }

        // GET: api/Attribute_Value/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attribute_Value>> GetAttribute_Value(Guid id)
        {
            var attribute_Value = await _context.Attribute_Values.FindAsync(id);

            if (attribute_Value == null)
            {
                return NotFound();
            }

            return attribute_Value;
        }

        // POST: api/Attribute_Value
        [HttpPost]
        public async Task<ActionResult<Attribute_Value>> PostAttribute_Value(Attribute_Value attribute_Value)
        {
            _context.Attribute_Values.Add(attribute_Value);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttribute_Value", new { id = attribute_Value.id }, attribute_Value);
        }

        // PUT: api/Attribute_Value/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttribute_Value(Guid id, Attribute_Value attribute_Value)
        {
            if (id != attribute_Value.id)
            {
                return BadRequest();
            }

            _context.Entry(attribute_Value).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Attribute_ValueExists(id))
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

        // DELETE: api/Attribute_Value/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute_Value(Guid id)
        {
            var attribute_Value = await _context.Attribute_Values.FindAsync(id);
            if (attribute_Value == null)
            {
                return NotFound();
            }

            _context.Attribute_Values.Remove(attribute_Value);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Attribute_ValueExists(Guid id)
        {
            return _context.Attribute_Values.Any(e => e.id == id);
        }
    }
}
