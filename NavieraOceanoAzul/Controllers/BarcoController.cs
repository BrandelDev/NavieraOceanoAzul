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
    public class BarcoController : ControllerBase
    {
        private readonly noaContext _context;
        private readonly IMapper _mapper;

        public BarcoController(noaContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/barco
        [HttpGet]
        public async Task<IActionResult> GetAllBarcos()
        {
            return _context.Barcos != null ?
                        Ok(await _context.Barcos.ToListAsync()) :
                        Problem("Entity set 'noaContext.Barcos'  is null.");
        }

        // GET: api/barco/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> GetBarco(int? id)
        {
            if (id == null || _context.Barcos == null)
            {
                return NotFound();
            }

            var barco = await _context.Barcos.FirstOrDefaultAsync(m => m.Idbarco == id);
            if (barco == null)
            {
                return NotFound();
            }

            return Ok(barco);
        }

        // POST: api/barco/Create
        [HttpPost("Create")]
        public async Task<IActionResult> CreateBarco([FromBody] BarcoDTO barcoDTO)
        {
            var barco = _mapper.Map<Barco>(barcoDTO);

            if (ModelState.IsValid)
            {
                _context.Add(barco);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBarco), new { id = barco.Idbarco }, barco);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/barco/Edit/5
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> EditBarco(int id, [FromBody] BarcoDTO barcoDto)
        {
            var barco = _mapper.Map<Barco>(barcoDto);
            if (id != barco.Idbarco)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarcoExists(barco.Idbarco))
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
            return BadRequest(ModelState);
        }

        // DELETE: api/barco/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBarco(int id)
        {
            var barco = await _context.Barcos.FindAsync(id);
            if (barco == null)
            {
                return NotFound();
            }

            _context.Barcos.Remove(barco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarcoExists(int id)
        {
            return _context.Barcos.Any(e => e.Idbarco == id);
        }
    }
}