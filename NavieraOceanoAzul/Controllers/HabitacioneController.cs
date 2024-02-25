using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NavieraOceanoAzul.DTO;
using NavieraOceanoAzul.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NavieraOceanoAzul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HabitacionController : ControllerBase
    {
        private readonly noaContext _context;
        private readonly IMapper _mapper;

        public HabitacionController(noaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Habitacione
        [HttpGet]
        public async Task<IActionResult> GetAllHabitaciones()
        {
            var habitaciones = await _context.Habitaciones.ToListAsync();
            if (habitaciones == null || habitaciones.Count == 0)
            {
                return NotFound();
            }
            return Ok(habitaciones);
        }

        // GET: api/Habitacione/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHabitacion(int id)
        {
            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok(habitacion);
        }

        // POST: api/Habitacione
        [HttpPost]
        public async Task<IActionResult> CreateHabitacion([FromBody] Habitacion habitacion)
        {
            
            if (ModelState.IsValid)
            {
                _context.Habitaciones.Add(habitacion);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetHabitacion), new { id = habitacion.Idhabitaciones }, habitacion);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Habitacione/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitacion(int id, [FromBody] HabitacionDTO habitacionDto)
        {
            var habitacion = _mapper.Map<Habitacion>(habitacionDto);
            if (id != habitacion.Idhabitaciones)
            {
                return BadRequest();
            }
            _context.Entry(habitacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Habitacione/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacion(int id)
        {
            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            _context.Habitaciones.Remove(habitacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}