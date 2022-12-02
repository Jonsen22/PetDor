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
    public class EspecialidadeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EspecialidadeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Especialidade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especialidades>>> GetEspecialidade()
        {
            return await _context.Especialidade.ToListAsync();
        }

        // GET: api/Especialidade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidades>> GetEspecialidade(int id)
        {
            var Especialidade = await _context.Especialidade.FindAsync(id);

            if (Especialidade == null)
            {
                return NotFound();
            }

            return Especialidade;
        }

        // PUT: api/Especialidade/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidade(int id, Especialidades Especialidade)
        {
            if (id != Especialidade.EspecialidadesId)
            {
                return BadRequest();
            }

            _context.Entry(Especialidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadeExists(id))
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

        // POST: api/Especialidade
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Especialidades>> PostEspecialidade(Especialidades Especialidade)
        {
            _context.Especialidade.Add(Especialidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecialidade", new { id = Especialidade.EspecialidadesId }, Especialidade);
        }

        // DELETE: api/Especialidade/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Especialidades>> DeleteEspecialidade(int id)
        {
            var Especialidade = await _context.Especialidade.FindAsync(id);
            if (Especialidade == null)
            {
                return NotFound();
            }

            _context.Especialidade.Remove(Especialidade);
            await _context.SaveChangesAsync();

            return Especialidade;
        }

        private bool EspecialidadeExists(int id)
        {
            return _context.Especialidade.Any(e => e.EspecialidadesId == id);
        }
    }
}
