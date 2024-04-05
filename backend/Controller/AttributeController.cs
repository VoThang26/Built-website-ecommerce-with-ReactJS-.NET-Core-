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
    public class AttributeController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public AttributeController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Attribute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Attribute>>> GetAttributes()
        {
            return await _context.Attributes.ToListAsync();
        }

        // GET: api/Attribute/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Attribute>> GetAttribute(Guid id)
        {
            var attribute = await _context.Attributes.FindAsync(id);

            if (attribute == null)
            {
                return NotFound();
            }

            return attribute;
        }

        // POST: api/Attribute
        [HttpPost]
        public async Task<ActionResult<Models.Attribute>> PostAttribute(Models.Attribute attribute)
        {
            _context.Attributes.Add(attribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttribute), new { id = attribute.id }, attribute);
        }

        // PUT: api/Attribute/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttribute(Guid id, Models.Attribute attribute)
        {
            if (id != attribute.id)
            {
                return BadRequest();
            }

            _context.Entry(attribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeExists(id))
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

        // DELETE: api/Attribute/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute(Guid id)
        {
            var attribute = await _context.Attributes.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }

            _context.Attributes.Remove(attribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttributeExists(Guid id)
        {
            return _context.Attributes.Any(e => e.id == id);
        }
    }
}
