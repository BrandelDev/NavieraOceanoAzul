using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NavieraOceanoAzul.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Importa los espacios de nombres para las anotaciones de Swagger

namespace NavieraOceanoAzul.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuertosController : ControllerBase
    {
        private readonly noaContext _context;

        public PuertosController(noaContext context)
        {
            _context = context;
        }

        // GET: api/Puertos
        [HttpGet]
        // Agrega las anotaciones de Swagger
        public async Task<ActionResult<IEnumerable<Puerto>>> GetPuertos()
        {
            return await _context.Puertos.ToListAsync();
        }

        // GET: api/Puertos/5
        [HttpGet("{id}")]
        // Agrega las anotaciones de Swagger
        public async Task<ActionResult<Puerto>> GetPuerto(int id)
        {
            var puerto = await _context.Puertos.FindAsync(id);

            if (puerto == null)
            {
                return NotFound();
            }

            return puerto;
        }

        // POST: api/Puertos
        [HttpPost]
        // Agrega las anotaciones de Swagger
        public async Task<ActionResult<Puerto>> CreatePuerto([FromBody] Puerto puerto)
        {
            _context.Puertos.Add(puerto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPuerto), new { id = puerto.IdPuertos }, puerto);
        }

        // PUT: api/Puertos/5
        [HttpPut("{id}")]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> UpdatePuerto(int id, [FromBody] Puerto puerto)
        {
            if (id != puerto.IdPuertos)
            {
                return BadRequest();
            }

            _context.Entry(puerto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuertoExists(id))
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

        // DELETE: api/Puertos/5
        [HttpDelete("{id}")]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> DeletePuerto(int id)
        {
            var puerto = await _context.Puertos.FindAsync(id);
            if (puerto == null)
            {
                return NotFound();
            }

            _context.Puertos.Remove(puerto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuertoExists(int id)
        {
            return _context.Puertos.Any(e => e.IdPuertos == id);
        }
    }
}