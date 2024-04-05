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
    public class GalleryController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public GalleryController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Gallery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gallery>>> GetGalleries()
        {
            return await _context.Galleries.ToListAsync();
        }

        // GET: api/Gallery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gallery>> GetGallery(Guid id)
        {
            var gallery = await _context.Galleries.FindAsync(id);

            if (gallery == null)
            {
                return NotFound();
            }

            return gallery;
        }

        // POST: api/Gallery
        [HttpPost]
        public async Task<ActionResult<Gallery>> PostGallery(Gallery gallery)
        {
            _context.Galleries.Add(gallery);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGallery), new { id = gallery.id }, gallery);
        }

        // PUT: api/Gallery/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGallery(Guid id, Gallery gallery)
        {
            if (id != gallery.id)
            {
                return BadRequest();
            }

            _context.Entry(gallery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryExists(id))
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

        // DELETE: api/Gallery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGallery(Guid id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }

            _context.Galleries.Remove(gallery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GalleryExists(Guid id)
        {
            return _context.Galleries.Any(e => e.id == id);
        }
    }
}
