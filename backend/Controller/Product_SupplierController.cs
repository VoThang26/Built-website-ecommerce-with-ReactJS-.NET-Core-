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
    public class Product_SupplierController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Product_SupplierController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Product_Supplier
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Supplier>>> GetProductSuppliers()
        {
            return await _context.Product_Suppliers.ToListAsync();
        }

        // GET: api/Product_Supplier/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Supplier>> GetProductSupplier(Guid id)
        {
            var productSupplier = await _context.Product_Suppliers.FindAsync(id);

            if (productSupplier == null)
            {
                return NotFound();
            }

            return productSupplier;
        }

        // POST: api/Product_Supplier
        [HttpPost]
        public async Task<ActionResult<Product_Supplier>> PostProductSupplier(Product_Supplier productSupplier)
        {
            _context.Product_Suppliers.Add(productSupplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductSupplier), new { id = productSupplier.id }, productSupplier);
        }

        // PUT: api/Product_Supplier/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSupplier(Guid id, Product_Supplier productSupplier)
        {
            if (id != productSupplier.id)
            {
                return BadRequest();
            }

            _context.Entry(productSupplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSupplierExists(id))
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

        // DELETE: api/Product_Supplier/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSupplier(Guid id)
        {
            var productSupplier = await _context.Product_Suppliers.FindAsync(id);
            if (productSupplier == null)
            {
                return NotFound();
            }

            _context.Product_Suppliers.Remove(productSupplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductSupplierExists(Guid id)
        {
            return _context.Product_Suppliers.Any(e => e.id == id);
        }
    }
}
