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
    public class Product_TagController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Product_TagController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Product_Tag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Tag>>> GetProductTags()
        {
            return await _context.Product_Tags.ToListAsync();
        }

        // GET: api/Product_Tag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Tag>> GetProductTag(Guid id)
        {
            var productTag = await _context.Product_Tags.FindAsync(id);

            if (productTag == null)
            {
                return NotFound();
            }

            return productTag;
        }

        // POST: api/Product_Tag
        [HttpPost]
        public async Task<ActionResult<Product_Tag>> PostProductTag(Product_Tag productTag)
        {
            _context.Product_Tags.Add(productTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductTag), new { id = productTag.id }, productTag);
        }

        // PUT: api/Product_Tag/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTag(Guid id, Product_Tag productTag)
        {
            if (id != productTag.id)
            {
                return BadRequest();
            }

            _context.Entry(productTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTagExists(id))
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

        // DELETE: api/Product_Tag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTag(Guid id)
        {
            var productTag = await _context.Product_Tags.FindAsync(id);
            if (productTag == null)
            {
                return NotFound();
            }

            _context.Product_Tags.Remove(productTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTagExists(Guid id)
        {
            return _context.Product_Tags.Any(e => e.id == id);
        }
    }
}
