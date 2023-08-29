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
    public class HabilidadesController : Controller
    {
        private readonly OracleDbContext _context;

        public HabilidadesController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Habilidades
        public async Task<IActionResult> Index()
        {
            var oracleDbContext = _context.Habilidades.Include(h => h.Carta);
            return View(await oracleDbContext.ToListAsync());
        }

        // GET: Habilidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habilidades == null)
            {
                return NotFound();
            }

            var habilidade = await _context.Habilidades
                .Include(h => h.Carta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habilidade == null)
            {
                return NotFound();
            }

            return View(habilidade);
        }

        // GET: Habilidades/Create
        public IActionResult Create()
        {
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome");
            return View();
        }

        // POST: Habilidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CartaId")] Habilidade habilidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habilidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome", habilidade.CartaId);
            return View(habilidade);
        }

        // GET: Habilidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habilidades == null)
            {
                return NotFound();
            }

            var habilidade = await _context.Habilidades.FindAsync(id);
            if (habilidade == null)
            {
                return NotFound();
            }
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome", habilidade.CartaId);
            return View(habilidade);
        }

        // POST: Habilidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CartaId")] Habilidade habilidade)
        {
            if (id != habilidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habilidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabilidadeExists(habilidade.Id))
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
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome", habilidade.CartaId);
            return View(habilidade);
        }

        // GET: Habilidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habilidades == null)
            {
                return NotFound();
            }

            var habilidade = await _context.Habilidades
                .Include(h => h.Carta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habilidade == null)
            {
                return NotFound();
            }

            return View(habilidade);
        }

        // POST: Habilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habilidades == null)
            {
                return Problem("Entity set 'OracleDbContext.Habilidades'  is null.");
            }
            var habilidade = await _context.Habilidades.FindAsync(id);
            if (habilidade != null)
            {
                _context.Habilidades.Remove(habilidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabilidadeExists(int id)
        {
          return (_context.Habilidades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
