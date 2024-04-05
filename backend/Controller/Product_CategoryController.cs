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
    public class Product_CategoryController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Product_CategoryController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Product_Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Category>>> GetProductCategories()
        {
            return await _context.Product_Categories.ToListAsync();
        }

        // GET: api/Product_Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Category>> GetProductCategory(Guid id)
        {
            var productCategory = await _context.Product_Categories.FindAsync(id);

            if (productCategory == null)
            {
                return NotFound();
            }

            return productCategory;
        }

        // POST: api/Product_Category
        [HttpPost]
        public async Task<ActionResult<Product_Category>> PostProductCategory(Product_Category productCategory)
        {
            _context.Product_Categories.Add(productCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductCategory), new { id = productCategory.id }, productCategory);
        }

        // PUT: api/Product_Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(Guid id, Product_Category productCategory)
        {
            if (id != productCategory.id)
            {
                return BadRequest();
            }

            _context.Entry(productCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(id))
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

        // DELETE: api/Product_Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(Guid id)
        {
            var productCategory = await _context.Product_Categories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            _context.Product_Categories.Remove(productCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductCategoryExists(Guid id)
        {
            return _context.Product_Categories.Any(e => e.id == id);
        }
    }
}
