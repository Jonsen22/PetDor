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
    public class VetEspecialidadesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VetEspecialidadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/VetEspecialidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VetEspecialidades>>> GetVetEspecialidades()
        {
            return await _context.VetEspecialidades.ToListAsync();
        }

        // GET: api/VetEspecialidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VetEspecialidades>> GetVetEspecialidades(int id)
        {
            var VetEspecialidades = await _context.VetEspecialidades.FindAsync(id);

            if (VetEspecialidades == null)
            {
                return NotFound();
            }

            return VetEspecialidades;
        }

        // PUT: api/VetEspecialidades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVetEspecialidades(int id, VetEspecialidades VetEspecialidades)
        {
            if (id != VetEspecialidades.VeterinarioId)
            {
                return BadRequest();
            }

            _context.Entry(VetEspecialidades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VetEspecialidadesExists(id))
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

        // POST: api/VetEspecialidades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VetEspecialidades>> PostVetEspecialidades(VetEspecialidades VetEspecialidades)
        {
            _context.VetEspecialidades.Add(VetEspecialidades);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VetEspecialidadesExists(VetEspecialidades.VeterinarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVetEspecialidades", new { id = VetEspecialidades.VeterinarioId }, VetEspecialidades);
        }

        // DELETE: api/VetEspecialidades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VetEspecialidades>> DeleteVetEspecialidades(int id)
        {
            var VetEspecialidades = await _context.VetEspecialidades.FindAsync(id);
            if (VetEspecialidades == null)
            {
                return NotFound();
            }

            _context.VetEspecialidades.Remove(VetEspecialidades);
            await _context.SaveChangesAsync();

            return VetEspecialidades;
        }

        private bool VetEspecialidadesExists(int id)
        {
            return _context.VetEspecialidades.Any(e => e.VeterinarioId == id);
        }
    }
}
