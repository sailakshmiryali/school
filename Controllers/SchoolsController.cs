#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School;
using School.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public SchoolsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Schools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schools>>> GetSchoolsList()
        {
            return await _context.SchoolsList.ToListAsync();
        }

        // GET: api/Schools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schools>> GetSchools(int id)
        {
            var schools = await _context.SchoolsList.FindAsync(id);

            if (schools == null)
            {
                return NotFound();
            }

            return schools;
        }

        // PUT: api/Schools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchools(int id, Schools schools)
        {
            if (id != schools.Id)
            {
                return BadRequest();
            }

            _context.Entry(schools).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolsExists(id))
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

        // POST: api/Schools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schools>> PostSchools(Schools schools)
        {
            _context.SchoolsList.Add(schools);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchools", new { id = schools.Id }, schools);
        }

        // DELETE: api/Schools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchools(int id)
        {
            var schools = await _context.SchoolsList.FindAsync(id);
            if (schools == null)
            {
                return NotFound();
            }

            _context.SchoolsList.Remove(schools);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolsExists(int id)
        {
            return _context.SchoolsList.Any(e => e.Id == id);
        }
    }
}
