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
    public class MedicSpeacilitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicSpeacilitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicSpeacilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VetEspecialidades>>> GetMedicSpeacilities()
        {
            return await _context.VetEspecialidades.ToListAsync();
        }

        // GET: api/MedicSpeacilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VetEspecialidades>> GetMedicSpeacilities(int id)
        {
            var medicSpeacilities = await _context.VetEspecialidades.FindAsync(id);

            if (medicSpeacilities == null)
            {
                return NotFound();
            }

            return medicSpeacilities;
        }

        // PUT: api/MedicSpeacilities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicSpeacilities(int id, VetEspecialidades medicSpeacilities)
        {
            if (id != medicSpeacilities.VeterinarioId)
            {
                return BadRequest();
            }

            _context.Entry(medicSpeacilities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicSpeacilitiesExists(id))
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

        // POST: api/MedicSpeacilities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VetEspecialidades>> PostMedicSpeacilities(VetEspecialidades medicSpeacilities)
        {
            _context.VetEspecialidades.Add(medicSpeacilities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicSpeacilitiesExists(medicSpeacilities.VeterinarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicSpeacilities", new { id = medicSpeacilities.VeterinarioId }, medicSpeacilities);
        }

        // DELETE: api/MedicSpeacilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VetEspecialidades>> DeleteMedicSpeacilities(int id)
        {
            var medicSpeacilities = await _context.VetEspecialidades.FindAsync(id);
            if (medicSpeacilities == null)
            {
                return NotFound();
            }

            _context.VetEspecialidades.Remove(medicSpeacilities);
            await _context.SaveChangesAsync();

            return medicSpeacilities;
        }

        private bool MedicSpeacilitiesExists(int id)
        {
            return _context.VetEspecialidades.Any(e => e.VeterinarioId == id);
        }
    }
}
