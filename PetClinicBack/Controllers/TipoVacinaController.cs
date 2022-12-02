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
    public class TipoVacinaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoVacinaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoVacina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVacina>>> GetVacina()
        {
            return await _context.TipoVacina.ToListAsync();
        }

        // GET: api/TipoVacina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVacina>> GetVacina(int id)
        {
            var TipoVacina = await _context.TipoVacina.FindAsync(id);

            if (TipoVacina == null)
            {
                return NotFound();
            }

            return TipoVacina;
        }

        // PUT: api/TipoVacina/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacina(int id, TipoVacina TipoVacina)
        {
            if (id != TipoVacina.TipoVacinaId)
            {
                return BadRequest();
            }

            _context.Entry(TipoVacina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVacinaExists(id))
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

        // POST: api/TipoVacina
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoVacina>> PostVacina(TipoVacina TipoVacina)
        {
            _context.TipoVacina.Add(TipoVacina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacina", new { id = TipoVacina.TipoVacinaId }, TipoVacina);
        }

        // DELETE: api/Vacina/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoVacina>> DeleteVacina(int id)
        {
            var TipoVacina = await _context.TipoVacina.FindAsync(id);
            if (TipoVacina == null)
            {
                return NotFound();
            }

            _context.TipoVacina.Remove(TipoVacina);
            await _context.SaveChangesAsync();

            return TipoVacina;
        }

        private bool TipoVacinaExists(int id)
        {
            return _context.TipoVacina.Any(e => e.TipoVacinaId == id);
        }
    }
}
