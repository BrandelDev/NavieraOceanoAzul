using Microsoft.AspNetCore.Authorization;
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
    public class RutasController : ControllerBase
    {
        private readonly noaContext _context;

        public RutasController(noaContext context)
        {
            _context = context;
        }

        // GET: api/Rutas
        [HttpGet]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> GetAllRutas()
        {
            return _context.Rutas != null ?
                Ok(await _context.Rutas.ToListAsync()) :
                Problem("Entity set 'noaContext.Rutas'  is null.");
        }

        // GET: api/Rutas/5
        [HttpGet("{id}")]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> GetRuta(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta == null)
            {
                return NotFound();
            }
            return Ok(ruta);
        }

        [HttpGet("GetRutasByPuerto/{puertoId}")]

        public async Task<IActionResult> GetRutasByPuerto(int puertoId)
        {
            var puerto = await _context.Puertos.FindAsync(puertoId);

            if (puerto == null)
            {
                return NotFound();
            }

            var rutas = await _context.Rutas
                                    .Where(r => r.PuertoOrigen == puertoId)
                                    .ToListAsync();
            return Ok(rutas);
        }

        // POST: api/Rutas
        [HttpPost]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> CreateRuta([FromBody] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                _context.Rutas.Add(ruta);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetRuta), new { id = ruta.IdRutas }, ruta);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Rutas/5
        [HttpPut("{id}")]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> UpdateRuta(int id, [FromBody] Ruta ruta)
        {
            if (id != ruta.IdRutas)
            {
                return BadRequest();
            }

            _context.Entry(ruta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutaExists(id))
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

        // DELETE: api/Rutas/5
        [HttpDelete("{id}")]
        // Agrega las anotaciones de Swagger
        public async Task<IActionResult> DeleteRuta(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta == null)
            {
                return NotFound();
            }

            _context.Rutas.Remove(ruta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RutaExists(int id)
        {
            return _context.Rutas.Any(e => e.IdRutas == id);
        }
    }
}