using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScryFallManager.Data;
using ScryFallManager.Entities;

namespace ScryFallManager.Controllers
{
    public class IdiomasController : Controller
    {
        private readonly OracleDbContext _context;

        public IdiomasController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Idiomas
        public async Task<IActionResult> Index()
        {
            var oracleDbContext = _context.Idiomas.Include(i => i.Carta);
            return View(await oracleDbContext.ToListAsync());
        }

        // GET: Idiomas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Idiomas == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idiomas
                .Include(i => i.Carta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idioma == null)
            {
                return NotFound();
            }

            return View(idioma);
        }

        // GET: Idiomas/Create
        public IActionResult Create()
        {
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome");
            return View();
        }

        // POST: Idiomas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CartaId")] Idioma idioma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(idioma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome", idioma.CartaId);
            return View(idioma);
        }

        // GET: Idiomas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Idiomas == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idiomas.FindAsync(id);
            if (idioma == null)
            {
                return NotFound();
            }
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome", idioma.CartaId);
            return View(idioma);
        }

        // POST: Idiomas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CartaId")] Idioma idioma)
        {
            if (id != idioma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idioma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdiomaExists(idioma.Id))
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
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome", idioma.CartaId);
            return View(idioma);
        }

        // GET: Idiomas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Idiomas == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idiomas
                .Include(i => i.Carta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idioma == null)
            {
                return NotFound();
            }

            return View(idioma);
        }

        // POST: Idiomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Idiomas == null)
            {
                return Problem("Entity set 'OracleDbContext.Idiomas'  is null.");
            }
            var idioma = await _context.Idiomas.FindAsync(id);
            if (idioma != null)
            {
                _context.Idiomas.Remove(idioma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdiomaExists(int id)
        {
          return (_context.Idiomas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
