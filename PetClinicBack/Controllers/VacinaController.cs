using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetDoor.Models;

namespace PetDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VacinaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vacina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacina>>> GetVacina()
        {
            return await _context.Vacina.Include(VP => VP.TipoVacina).ToListAsync();
        }

        // GET: api/Vacina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacina>> GetVacina(int id)
        {
            var TipoVacina = await _context.Vacina.Include(v => v.TipoVacina)
                .SingleOrDefaultAsync(v => v.VacinaId == id);

            if (TipoVacina == null)
            {
                return NotFound();
            }

            return TipoVacina;
        }

        // PUT: api/Vacina/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVacina(int id, Vacina Vacina)
        {
            if (id != Vacina.VacinaId)
            {
                return BadRequest();
            }

            _context.Entry(Vacina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacinaExists(id))
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

        // POST: api/Vacina
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vacina>> PostTipoVacina(Vacina Vacina)
        {
            _context.Vacina.Add(Vacina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoVacina", new { id = Vacina.VacinaId }, Vacina);
        }

        // DELETE: api/Vacina/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vacina>> DeleteTipoVacina(int id)
        {
            var Vacina = await _context.Vacina.FindAsync(id);
            if (Vacina == null)
            {
                return NotFound();
            }

            _context.Vacina.Remove(Vacina);
            await _context.SaveChangesAsync();

            return Vacina;
        }

        private bool VacinaExists(int id)
        {
            return _context.Vacina.Any(e => e.VacinaId == id);
        }
    }
}
