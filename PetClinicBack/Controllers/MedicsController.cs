using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetClinicBack.Models;
using PetShopBack.Models;

namespace PetClinicBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Medics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinario>>> GetMedics()
        {
            return await _context.Veterinario.Include(m => m.VetEspecialidade).ToListAsync();
        }

        // GET: api/Medics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinario>> GetMedic(int id)
        {
            var medic = await _context.Veterinario.FindAsync(id);

            if (medic == null)
            {
                return NotFound();
            }

            return medic;
        }

        // PUT: api/Medics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedic(int id, Veterinario medic)
        {
            if (id != medic.VeterinarioId)
            {
                return BadRequest();
            }

            _context.Entry(medic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicExists(id))
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

        // POST: api/Medics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Veterinario>> PostMedic(Veterinario medic)
        {
            _context.Veterinario.Add(medic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedic", new { id = medic.VeterinarioId }, medic);
        }

        // DELETE: api/Medics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Veterinario>> DeleteMedic(int id)
        {
            var medic = await _context.Veterinario.FindAsync(id);
            if (medic == null)
            {
                return NotFound();
            }

            _context.Veterinario.Remove(medic);
            await _context.SaveChangesAsync();

            return medic;
        }

        private bool MedicExists(int id)
        {
            return _context.Veterinario.Any(e => e.VeterinarioId == id);
        }
    }
}
