using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NavieraOceanoAzul.Models;

namespace NavieraOceanoAzul.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class BarcoController : Controller
    {
        private readonly noaContext _context;

        public BarcoController(noaContext context)
        {
            _context = context;
        }

        // GET: Barco
        [Route("ListShip")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.Barcos != null ? 
                          View(await _context.Barcos.ToListAsync()) :
                          Problem("Entity set 'noaContext.Barcos'  is null.");
        }
        [Route("ListShipByID/{id}")]
        [HttpGet]
        // GET: Barco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Barcos == null)
            {
                return NotFound();
            }

            var barco = await _context.Barcos
                .FirstOrDefaultAsync(m => m.Idbarco == id);
            if (barco == null)
            {
                return NotFound();
            }

            return View(barco);
        }

        // GET: Barco/Create
 
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("CreateShip")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idbarco,CapacidadPersonas,CapacidadCarga,NombreBarco,Idtiquete")] Barco barco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barco);
        }

        // GET: Barco/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Barcos == null)
            {
                return NotFound();
            }

            var barco = await _context.Barcos.FindAsync(id);
            if (barco == null)
            {
                return NotFound();
            }
            return View(barco);
        }

        // POST: Barco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Route("EditShip/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idbarco,CapacidadPersonas,CapacidadCarga,NombreBarco,Idtiquete")] Barco barco)
        {
            if (id != barco.Idbarco)
            {
                return NotFound();
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
                return RedirectToAction(nameof(Index));
            }
            return View(barco);
        }

        // GET: Barco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Barcos == null)
            {
                return NotFound();
            }

            var barco = await _context.Barcos
                .FirstOrDefaultAsync(m => m.Idbarco == id);
            if (barco == null)
            {
                return NotFound();
            }

            return View(barco);
        }

        // POST: Barco/Delete/5
        [Route("DeleteShip/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Barcos == null)
            {
                return Problem("Entity set 'noaContext.Barcos'  is null.");
            }
            var barco = await _context.Barcos.FindAsync(id);
            if (barco != null)
            {
                _context.Barcos.Remove(barco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarcoExists(int id)
        {
          return (_context.Barcos?.Any(e => e.Idbarco == id)).GetValueOrDefault();
        }
    }
}
