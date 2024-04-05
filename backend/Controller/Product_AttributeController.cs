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
    public class Product_AttributeController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Product_AttributeController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Product_Attribute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Attribute>>> GetProductAttributes()
        {
            return await _context.Product_Attributes.ToListAsync();
        }

        // GET: api/Product_Attribute/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Attribute>> GetProductAttribute(Guid id)
        {
            var productAttribute = await _context.Product_Attributes.FindAsync(id);

            if (productAttribute == null)
            {
                return NotFound();
            }

            return productAttribute;
        }

        // POST: api/Product_Attribute
        [HttpPost]
        public async Task<ActionResult<Product_Attribute>> PostProductAttribute(Product_Attribute productAttribute)
        {
            _context.Product_Attributes.Add(productAttribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductAttribute), new { id = productAttribute.id }, productAttribute);
        }

        // PUT: api/Product_Attribute/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductAttribute(Guid id, Product_Attribute productAttribute)
        {
            if (id != productAttribute.id)
            {
                return BadRequest();
            }

            _context.Entry(productAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductAttributeExists(id))
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

        // DELETE: api/Product_Attribute/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAttribute(Guid id)
        {
            var productAttribute = await _context.Product_Attributes.FindAsync(id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            _context.Product_Attributes.Remove(productAttribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductAttributeExists(Guid id)
        {
            return _context.Product_Attributes.Any(e => e.id == id);
        }
    }
}
