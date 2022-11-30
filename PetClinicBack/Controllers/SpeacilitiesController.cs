using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetClinicBack.Models;

namespace PetClinicBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeacilitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SpeacilitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Speacilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especialidades>>> GetSpeacilities()
        {
            return await _context.Especialidade.ToListAsync();
        }

        // GET: api/Speacilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidades>> GetSpeacilities(int id)
        {
            var speacilities = await _context.Especialidade.FindAsync(id);

            if (speacilities == null)
            {
                return NotFound();
            }

            return speacilities;
        }

        // PUT: api/Speacilities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeacilities(int id, Especialidades speacilities)
        {
            if (id != speacilities.EspecialidadesId)
            {
                return BadRequest();
            }

            _context.Entry(speacilities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeacilitiesExists(id))
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

        // POST: api/Speacilities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Especialidades>> PostSpeacilities(Especialidades speacilities)
        {
            _context.Especialidade.Add(speacilities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpeacilities", new { id = speacilities.EspecialidadesId }, speacilities);
        }

        // DELETE: api/Speacilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Especialidades>> DeleteSpeacilities(int id)
        {
            var speacilities = await _context.Especialidade.FindAsync(id);
            if (speacilities == null)
            {
                return NotFound();
            }

            _context.Especialidade.Remove(speacilities);
            await _context.SaveChangesAsync();

            return speacilities;
        }

        private bool SpeacilitiesExists(int id)
        {
            return _context.Especialidade.Any(e => e.EspecialidadesId == id);
        }
    }
}
