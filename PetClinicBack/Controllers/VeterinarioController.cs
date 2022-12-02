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
    public class VeterinarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeterinarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Veterinario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinario>>> GetVeterinario()
        {
            return await _context.Veterinario.Include(m => m.VetEspecialidade).ToListAsync();
        }

        // GET: api/Veterinario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinario>> GetVeterinario(int id)
        {
            var medic = await _context.Veterinario.FindAsync(id);

            if (medic == null)
            {
                return NotFound();
            }

            return medic;
        }

        // PUT: api/Veterinario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedic(int id, Veterinario Veterinario)
        {
            if (id != Veterinario.VeterinarioId)
            {
                return BadRequest();
            }

            _context.Entry(Veterinario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinarioExists(id))
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

        // POST: api/Veterinario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Veterinario>> PostMedic(Veterinario Veterinario)
        {
            _context.Veterinario.Add(Veterinario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedic", new { id = Veterinario.VeterinarioId }, Veterinario);
        }

        // DELETE: api/Veterinario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Veterinario>> DeleteVeterinario(int id)
        {
            var Veterinario = await _context.Veterinario.FindAsync(id);
            if (Veterinario == null)
            {
                return NotFound();
            }

            _context.Veterinario.Remove(Veterinario);
            await _context.SaveChangesAsync();

            return Veterinario;
        }

        private bool VeterinarioExists(int id)
        {
            return _context.Veterinario.Any(e => e.VeterinarioId == id);
        }
    }
}
