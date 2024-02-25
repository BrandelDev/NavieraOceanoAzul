using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NavieraOceanoAzul.Models;
using System.Linq;
using System.Threading.Tasks;
// Importa los espacios de nombres para las anotaciones de Swagger

namespace NavieraOceanoAzul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionPuertoBarcoesController : ControllerBase
    {
        private readonly noaContext _context;

        public AsignacionPuertoBarcoesController(noaContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionPuertoBarcoes
        [HttpGet]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> GetAllAsignacionPuertoBarcoes()
        {
            var noaContext = _context.AsignacionPuertoBarcos.Include(a => a.IdbarcoNavigation).Include(a => a.IdpuertoNavigation);
            return Ok(await noaContext.ToListAsync());
        }

        // GET: api/AsignacionPuertoBarcoes/5
        [HttpGet("{id}")]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> GetAsignacionPuertoBarco(int id)
        {
            var asignacionPuertoBarco = await _context.AsignacionPuertoBarcos
                .Include(a => a.IdbarcoNavigation)
                .Include(a => a.IdpuertoNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacionPuertoBarco == id);
            if (asignacionPuertoBarco == null)
            {
                return NotFound();
            }
            return Ok(asignacionPuertoBarco);
        }

        // POST: api/AsignacionPuertoBarcoes
        [HttpPost]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> CreateAsignacionPuertoBarco([FromBody] AsignacionPuertoBarco asignacionPuertoBarco)
        {
            if (ModelState.IsValid)
            {
                _context.AsignacionPuertoBarcos.Add(asignacionPuertoBarco);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAsignacionPuertoBarco), new { id = asignacionPuertoBarco.IdAsignacionPuertoBarco }, asignacionPuertoBarco);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/AsignacionPuertoBarcoes/5
        [HttpPut("{id}")]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> UpdateAsignacionPuertoBarco(int id, [FromBody] AsignacionPuertoBarco asignacionPuertoBarco)
        {
            if (id != asignacionPuertoBarco.IdAsignacionPuertoBarco)
            {
                return BadRequest();
            }

            _context.Entry(asignacionPuertoBarco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionPuertoBarcoExists(id))
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

        // DELETE: api/AsignacionPuertoBarcoes/5
        [HttpDelete("{id}")]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> DeleteAsignacionPuertoBarco(int id)
        {
            var asignacionPuertoBarco = await _context.AsignacionPuertoBarcos.FindAsync(id);
            if (asignacionPuertoBarco == null)
            {
                return NotFound();
            }

            _context.AsignacionPuertoBarcos.Remove(asignacionPuertoBarco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacionPuertoBarcoExists(int id)
        {
            return _context.AsignacionPuertoBarcos.Any(e => e.IdAsignacionPuertoBarco == id);
        }
    }
}