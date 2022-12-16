using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetDoor.Models;
using PetDoor.Services;
using PetDoor.Exceptions;

namespace PetDoor.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TutorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Tutors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutors()
        {
     
            return await _context.Tutor.Include(u => u.Pets)
                .ThenInclude(Pets => Pets.Vacinas)
                .ThenInclude(Vacinas => Vacinas.TipoVacina).ToListAsync();
        }

        // GET: api/Tutors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetTutor(int id)
        {
            var Tutor = await _context.Tutor.Include(u => u.Pets)
                .ThenInclude(Pets => Pets.Vacinas)
                .ThenInclude(Vacinas => Vacinas.TipoVacina)
                .SingleOrDefaultAsync(u => u.TutorId == id);

            if (Tutor == null)
            {
                return NotFound();
            }

            return Tutor;
        }

        // PUT: api/Tutors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutor(int id, Tutor Tutor)
        {
            if (id != Tutor.TutorId)
            {
                return BadRequest();
            }

            _context.Entry(Tutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
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

        // POST: api/Tutors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tutor>> PostTutor(Tutor Tutor)
        {
            _context.Tutor.Add(Tutor);
            await _context.SaveChangesAsync();

            try
            {
                string cpfValidado = Funcoes.ValidarCpf(Tutor.CPF);
                
                if(cpfValidado == "CPF Inválido")
                    return BadRequest("CPF Inválido");
            }
            catch(CpfInvalidoException)
            {
                return BadRequest("CPF Inválido");
            }

            return CreatedAtAction("GetTutor", new { id = Tutor.TutorId }, Tutor);
        }

        // DELETE: api/Tutors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tutor>> DeleteTutor(int id)
        {
            var Tutor = await _context.Tutor.FindAsync(id);
            if (Tutor == null)
            {
                return NotFound();
            }

            _context.Tutor.Remove(Tutor);
            await _context.SaveChangesAsync();

            return Tutor;
        }

        private bool TutorExists(int id)
        {
            return _context.Tutor.Any(e => e.TutorId == id);
        }
    }
}
