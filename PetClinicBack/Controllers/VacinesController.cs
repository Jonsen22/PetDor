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
    public class VacinesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VacinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vacines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVacina>>> GetVacines()
        {
            return await _context.TipoVacina.ToListAsync();
        }

        // GET: api/Vacines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVacina>> GetVacines(int id)
        {
            var vacines = await _context.TipoVacina.FindAsync(id);

            if (vacines == null)
            {
                return NotFound();
            }

            return vacines;
        }

        // PUT: api/Vacines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacines(int id, TipoVacina vacines)
        {
            if (id != vacines.TipoVacinaId)
            {
                return BadRequest();
            }

            _context.Entry(vacines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacinesExists(id))
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

        // POST: api/Vacines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoVacina>> PostVacines(TipoVacina vacines)
        {
            _context.TipoVacina.Add(vacines);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacines", new { id = vacines.TipoVacinaId }, vacines);
        }

        // DELETE: api/Vacines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoVacina>> DeleteVacines(int id)
        {
            var vacines = await _context.TipoVacina.FindAsync(id);
            if (vacines == null)
            {
                return NotFound();
            }

            _context.TipoVacina.Remove(vacines);
            await _context.SaveChangesAsync();

            return vacines;
        }

        private bool VacinesExists(int id)
        {
            return _context.TipoVacina.Any(e => e.TipoVacinaId == id);
        }
    }
}
