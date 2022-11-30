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
    public class VacineAplicationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VacineAplicationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/VacineAplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacina>>> GetVacinesAplication()
        {
            return await _context.Vacina.Include(VP => VP.TipoVacina).ToListAsync();
        }

        // GET: api/VacineAplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacina>> GetVacineAplication(int id)
        {
            var vacineAplication = await _context.Vacina.FindAsync(id);

            if (vacineAplication == null)
            {
                return NotFound();
            }

            return vacineAplication;
        }

        // PUT: api/VacineAplications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacineAplication(int id, Vacina vacineAplication)
        {
            if (id != vacineAplication.TipoVacinaId)
            {
                return BadRequest();
            }

            _context.Entry(vacineAplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacineAplicationExists(id))
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

        // POST: api/VacineAplications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vacina>> PostVacineAplication(Vacina vacineAplication)
        {
            _context.Vacina.Add(vacineAplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacineAplication", new { id = vacineAplication.TipoVacinaId }, vacineAplication);
        }

        // DELETE: api/VacineAplications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vacina>> DeleteVacineAplication(int id)
        {
            var vacineAplication = await _context.Vacina.FindAsync(id);
            if (vacineAplication == null)
            {
                return NotFound();
            }

            _context.Vacina.Remove(vacineAplication);
            await _context.SaveChangesAsync();

            return vacineAplication;
        }

        private bool VacineAplicationExists(int id)
        {
            return _context.Vacina.Any(e => e.TipoVacinaId == id);
        }
    }
}
