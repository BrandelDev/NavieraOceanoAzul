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
    public class TiquetesController : Controller
    {
        private readonly noaContext _context;

        public TiquetesController(noaContext context)
        {
            _context = context;
        }

        // GET: Tiquetes
        public async Task<IActionResult> Index()
        {
            var noaContext = _context.Tiquetes.Include(t => t.IdbarcoNavigation).Include(t => t.IdclienteNavigation);
            return View(await noaContext.ToListAsync());
        }

        // GET: Tiquetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tiquetes == null)
            {
                return NotFound();
            }

            var tiquete = await _context.Tiquetes
                .Include(t => t.IdbarcoNavigation)
                .Include(t => t.IdclienteNavigation)
                .FirstOrDefaultAsync(m => m.Idtiquete == id);
            if (tiquete == null)
            {
                return NotFound();
            }

            return View(tiquete);
        }

        // GET: Tiquetes/Create
        public IActionResult Create()
        {
            ViewData["Idbarco"] = new SelectList(_context.Barcos, "Idbarco", "Idbarco");
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Idcliente");
            return View();
        }

        // POST: Tiquetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtiquete,PuertoDestino,PuertoOrigen,Idcliente,FechaEmision,FechaSalida,Precio,Idbarco,FechaLlegada")] Tiquete tiquete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idbarco"] = new SelectList(_context.Barcos, "Idbarco", "Idbarco", tiquete.Idbarco);
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Idcliente", tiquete.Idcliente);
            return View(tiquete);
        }

        // GET: Tiquetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tiquetes == null)
            {
                return NotFound();
            }

            var tiquete = await _context.Tiquetes.FindAsync(id);
            if (tiquete == null)
            {
                return NotFound();
            }
            ViewData["Idbarco"] = new SelectList(_context.Barcos, "Idbarco", "Idbarco", tiquete.Idbarco);
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Idcliente", tiquete.Idcliente);
            return View(tiquete);
        }

        // POST: Tiquetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtiquete,PuertoDestino,PuertoOrigen,Idcliente,FechaEmision,FechaSalida,Precio,Idbarco,FechaLlegada")] Tiquete tiquete)
        {
            if (id != tiquete.Idtiquete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiqueteExists(tiquete.Idtiquete))
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
            ViewData["Idbarco"] = new SelectList(_context.Barcos, "Idbarco", "Idbarco", tiquete.Idbarco);
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Idcliente", tiquete.Idcliente);
            return View(tiquete);
        }

        // GET: Tiquetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tiquetes == null)
            {
                return NotFound();
            }

            var tiquete = await _context.Tiquetes
                .Include(t => t.IdbarcoNavigation)
                .Include(t => t.IdclienteNavigation)
                .FirstOrDefaultAsync(m => m.Idtiquete == id);
            if (tiquete == null)
            {
                return NotFound();
            }

            return View(tiquete);
        }

        // POST: Tiquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tiquetes == null)
            {
                return Problem("Entity set 'noaContext.Tiquetes'  is null.");
            }
            var tiquete = await _context.Tiquetes.FindAsync(id);
            if (tiquete != null)
            {
                _context.Tiquetes.Remove(tiquete);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiqueteExists(int id)
        {
          return (_context.Tiquetes?.Any(e => e.Idtiquete == id)).GetValueOrDefault();
        }
    }
}
