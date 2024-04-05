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
    public class Product_Attribute_ValueController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Product_Attribute_ValueController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Product_Attribute_Value
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Attribute_Value>>> GetProductAttributeValues()
        {
            return await _context.Product_Attribute_Values.ToListAsync();
        }

        // GET: api/Product_Attribute_Value/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Attribute_Value>> GetProductAttributeValue(Guid id)
        {
            var productAttributeValue = await _context.Product_Attribute_Values.FindAsync(id);

            if (productAttributeValue == null)
            {
                return NotFound();
            }

            return productAttributeValue;
        }

        // POST: api/Product_Attribute_Value
        [HttpPost]
        public async Task<ActionResult<Product_Attribute_Value>> PostProductAttributeValue(Product_Attribute_Value productAttributeValue)
        {
            _context.Product_Attribute_Values.Add(productAttributeValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductAttributeValue), new { id = productAttributeValue.id }, productAttributeValue);
        }

        // PUT: api/Product_Attribute_Value/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductAttributeValue(Guid id, Product_Attribute_Value productAttributeValue)
        {
            if (id != productAttributeValue.id)
            {
                return BadRequest();
            }

            _context.Entry(productAttributeValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductAttributeValueExists(id))
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

        // DELETE: api/Product_Attribute_Value/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAttributeValue(Guid id)
        {
            var productAttributeValue = await _context.Product_Attribute_Values.FindAsync(id);
            if (productAttributeValue == null)
            {
                return NotFound();
            }

            _context.Product_Attribute_Values.Remove(productAttributeValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductAttributeValueExists(Guid id)
        {
            return _context.Product_Attribute_Values.Any(e => e.id == id);
        }
    }
}
