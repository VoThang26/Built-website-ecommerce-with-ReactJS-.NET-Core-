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
    public class CategoryController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public CategoryController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetCategories()
        {
            // Truy vấn dữ liệu từ bảng Categories và chỉ lấy các trường cần thiết
            var categories = await _context
                .Categories.Select(c => new
                {
                    c.id,
                    c.parent_id,
                    c.category_name,
                    c.category_description,
                    c.icon,
                    c.image,
                    c.active,
                    c.created_at,
                    c.updated_at,
                    c.created_by,
                    c.updated_by
                    // Thêm các trường khác nếu cần
                })
                .ToListAsync();

            return categories;
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // // POST: api/Category
        // [HttpPost]
        // public async Task<ActionResult<Category>> PostCategory(Category category)
        // {
        //     _context.Categories.Add(category);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        // }
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCategory = new Category
            {
                parent_id = category.parent_id,
                category_name = category.category_name,
                category_description = category.category_description,
                icon = category.icon,
                image = category.image,
                active = category.active,
                created_at = DateTime.UtcNow,
                updated_at = null, // Since it's a new category, updated_at is null initially
                created_by = category.created_by,
                updated_by = category.created_by // Assuming the creator is also the updater initially
            };

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = newCategory.id }, newCategory);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, Category category)
        {
            if (id != category.id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(Guid id)
        {
            return _context.Categories.Any(e => e.id == id);
        }
    }
}
