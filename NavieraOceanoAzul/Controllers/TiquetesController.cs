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
    public class TiquetesController : ControllerBase
    {
        private readonly noaContext _context;
        private readonly IMapper _mapper;
        public TiquetesController(noaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Tiquetes
        [HttpGet]
        public async Task<IActionResult> GetAllTiquetes()
        {
            var tiquetes = await _context.Tiquetes.ToListAsync();
            if (tiquetes == null || tiquetes.Count == 0)
            {
                return NotFound();
            }
            return Ok(tiquetes);
        }

        // GET: api/Tiquetes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTiquete(int id)
        {
            var tiquete = await _context.Tiquetes.FindAsync(id);
            if (tiquete == null)
            {
                return NotFound();
            }
            return Ok(tiquete);
        }

        // POST: api/Tiquetes
        [HttpPost]
        public async Task<IActionResult> CreateTiquete([FromBody] TiqueteDTO tiqueteDto)
        {
            var tiquete  = _mapper.Map<Tiquete>(tiqueteDto);

            if (ModelState.IsValid)
            {
                _context.Tiquetes.Add(tiquete);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetTiquete), new { id = tiquete.Idtiquete }, tiquete);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Tiquetes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTiquete(int id, [FromBody] Tiquete tiqueteDto)
        {
            var tiquete = _mapper.Map<Tiquete>(tiqueteDto);

            if (id != tiquete.Idtiquete)
            {
                return BadRequest();
            }
            _context.Entry(tiquete).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Tiquetes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiquete(int id)
        {
            var tiquete = await _context.Tiquetes.FindAsync(id);
            if (tiquete == null)
            {
                return NotFound();
            }
            _context.Tiquetes.Remove(tiquete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}