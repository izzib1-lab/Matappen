using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Matapi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Matapi.Data;
using Matapi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatController : ControllerBase
    {
        private readonly MatApiContext _context;

        public MatController(MatApiContext context)
        {
            _context = context;
        }

        // Hämta alla maträtter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mat>>> GetMats()
        {
            return await _context.Mats.ToListAsync();
        }

        // Hämta en maträtt efter ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Mat>> GetMat(int id)
        {
            var mat = await _context.Mats.FindAsync(id);

            if (mat == null)
            {
                return NotFound(new { message = "Maträtten hittades inte." });
            }

            return Ok(mat);
        }

        // Skapa en ny maträtt
        [HttpPost]
        public async Task<ActionResult<Mat>> PostMat([FromBody] Mat mat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Mats.Add(mat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMat), new { id = mat.Id }, mat);
        }

        // Uppdatera en maträtt
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMat(int id, [FromBody] Mat mat)
        {
            if (id != mat.Id)
            {
                return BadRequest(new { message = "ID:t matchar inte." });
            }

            _context.Entry(mat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatExists(id))
                {
                    return NotFound(new { message = "Maträtten finns inte längre." });
                }
                throw;
            }

            return NoContent();
        }

        // Radera en maträtt
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMat(int id)
        {
            var mat = await _context.Mats.FindAsync(id);
            if (mat == null)
            {
                return NotFound(new { message = "Maträtten kunde inte hittas." });
            }

            _context.Mats.Remove(mat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatExists(int id)
        {
            return _context.Mats.Any(e => e.Id == id);
        }
    }
}
