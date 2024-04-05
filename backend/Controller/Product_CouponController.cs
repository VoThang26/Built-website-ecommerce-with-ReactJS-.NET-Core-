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
    public class Product_CouponController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public Product_CouponController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Product_Coupon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Coupon>>> GetProductCoupons()
        {
            return await _context.Product_Coupons.ToListAsync();
        }

        // GET: api/Product_Coupon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Coupon>> GetProductCoupon(Guid id)
        {
            var productCoupon = await _context.Product_Coupons.FindAsync(id);

            if (productCoupon == null)
            {
                return NotFound();
            }

            return productCoupon;
        }

        // POST: api/Product_Coupon
        [HttpPost]
        public async Task<ActionResult<Product_Coupon>> PostProductCoupon(Product_Coupon productCoupon)
        {
            _context.Product_Coupons.Add(productCoupon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductCoupon), new { id = productCoupon.id }, productCoupon);
        }

        // PUT: api/Product_Coupon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCoupon(Guid id, Product_Coupon productCoupon)
        {
            if (id != productCoupon.id)
            {
                return BadRequest();
            }

            _context.Entry(productCoupon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCouponExists(id))
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

        // DELETE: api/Product_Coupon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCoupon(Guid id)
        {
            var productCoupon = await _context.Product_Coupons.FindAsync(id);
            if (productCoupon == null)
            {
                return NotFound();
            }

            _context.Product_Coupons.Remove(productCoupon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductCouponExists(Guid id)
        {
            return _context.Product_Coupons.Any(e => e.id == id);
        }
    }
}
