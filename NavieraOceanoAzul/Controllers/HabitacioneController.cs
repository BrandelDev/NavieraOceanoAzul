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
    public class HabitacioneController : Controller
    {
        private readonly noaContext _context;

        public HabitacioneController(noaContext context)
        {
            _context = context;
        }

        // GET: Habitacione
        public async Task<IActionResult> Index()
        {
            var noaContext = _context.Habitaciones.Include(h => h.IdbarcoNavigation);
            return View(await noaContext.ToListAsync());
        }

        // GET: Habitacione/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitacione = await _context.Habitaciones
                .Include(h => h.IdbarcoNavigation)
                .FirstOrDefaultAsync(m => m.Idhabitacion == id);
            if (habitacione == null)
            {
                return NotFound();
            }

            return View(habitacione);
        }

        // GET: Habitacione/Create
        public IActionResult Create()
        {
            ViewData["Idbarco"] = new SelectList(_context.Barcos, "Idbarco", "Idbarco");
            return View();
        }

        // POST: Habitacione/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idhabitacion,Idbarco,NumeroHabitacion,Capacidad,UbicacionHabitacion")] Habitacione habitacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idbarco"] = new SelectList(_context.Barcos, "Idbarco", "Idbarco", habitacione.Idbarco);
            return View(habitacione);
        }

        // GET: Habitacione/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitacione = await _context.Habitaciones.FindAsync(id);
            if (habitacione == null)
            {
                return NotFound();
            }
            ViewData["Idbarco"] = new SelectList(_context.Barcos, "Idbarco", "Idbarco", habitacione.Idbarco);
            return View(habitacione);
        }

        // POST: Habitacione/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idhabitacion,Idbarco,NumeroHabitacion,Capacidad,UbicacionHabitacion")] Habitacione habitacione)
        {
            if (id != habitacione.Idhabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacioneExists(habitacione.Idhabitacion))
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
            ViewData["Idbarco"] = new SelectList(_context.Barcos, "Idbarco", "Idbarco", habitacione.Idbarco);
            return View(habitacione);
        }

        // GET: Habitacione/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitacione = await _context.Habitaciones
                .Include(h => h.IdbarcoNavigation)
                .FirstOrDefaultAsync(m => m.Idhabitacion == id);
            if (habitacione == null)
            {
                return NotFound();
            }

            return View(habitacione);
        }

        // POST: Habitacione/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habitaciones == null)
            {
                return Problem("Entity set 'noaContext.Habitaciones'  is null.");
            }
            var habitacione = await _context.Habitaciones.FindAsync(id);
            if (habitacione != null)
            {
                _context.Habitaciones.Remove(habitacione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacioneExists(int id)
        {
          return (_context.Habitaciones?.Any(e => e.Idhabitacion == id)).GetValueOrDefault();
        }
    }
}
