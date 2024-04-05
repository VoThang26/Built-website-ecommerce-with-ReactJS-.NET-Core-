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
    public class Product_Shipping_InfoController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Product_Shipping_InfoController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Product_Shipping_Info
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Shipping_Info>>> GetProductShippingInfo()
        {
            return await _context.Product_Shipping_Infos.ToListAsync();
        }

        // GET: api/Product_Shipping_Info/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Shipping_Info>> GetProductShippingInfo(Guid id)
        {
            var productShippingInfo = await _context.Product_Shipping_Infos.FindAsync(id);

            if (productShippingInfo == null)
            {
                return NotFound();
            }

            return productShippingInfo;
        }

        // POST: api/Product_Shipping_Info
        [HttpPost]
        public async Task<ActionResult<Product_Shipping_Info>> PostProductShippingInfo(Product_Shipping_Info productShippingInfo)
        {
            _context.Product_Shipping_Infos.Add(productShippingInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductShippingInfo), new { id = productShippingInfo.id }, productShippingInfo);
        }

        // PUT: api/Product_Shipping_Info/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductShippingInfo(Guid id, Product_Shipping_Info productShippingInfo)
        {
            if (id != productShippingInfo.id)
            {
                return BadRequest();
            }

            _context.Entry(productShippingInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductShippingInfoExists(id))
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

        // DELETE: api/Product_Shipping_Info/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductShippingInfo(Guid id)
        {
            var productShippingInfo = await _context.Product_Shipping_Infos.FindAsync(id);
            if (productShippingInfo == null)
            {
                return NotFound();
            }

            _context.Product_Shipping_Infos.Remove(productShippingInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductShippingInfoExists(Guid id)
        {
            return _context.Product_Shipping_Infos.Any(e => e.id == id);
        }
    }
}
