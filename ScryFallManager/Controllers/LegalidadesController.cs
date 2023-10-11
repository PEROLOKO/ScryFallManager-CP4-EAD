using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ScryFallManager.Data;
using ScryFallManager.Entities;

namespace ScryFallManager.Controllers
{
    public class LegalidadesController : Controller
    {
        private readonly OracleDbContext _context;
        private readonly IMemoryCache _cache;

        public LegalidadesController(OracleDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Legalidades
        public async Task<IActionResult> Index()
        {
            if (!_cache.TryGetValue("Legalidades", out List<Legalidade> legalidades))
            {
                legalidades = await _context.Legalidade.Include(l => l.Carta).ToListAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };
                _cache.Set("Legalidades", legalidades, cacheEntryOptions);
                return View(legalidades);
            }
            return View(legalidades);
        }

        // GET: Legalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Legalidade == null)
            {
                return NotFound();
            }

            if (!_cache.TryGetValue($"Legalidade_{id}", out Legalidade? legalidade))
            {
                legalidade = await _context.Legalidade
                    .Include(l => l.Carta)
                    .FirstOrDefaultAsync(m => m.Id == id);

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };

                if (legalidade != null)
                {
                    _cache.Set($"Legalidade_{id}", legalidade, cacheEntryOptions);
                }
            }

            if (legalidade == null)
            {
                return NotFound();
            }

            return View(legalidade);
        }

        // GET: Legalidades/Create
        public IActionResult Create()
        {
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome");
            return View();
        }

        // POST: Legalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Formato,Legal,CartaId")] Legalidade legalidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legalidade);
                await _context.SaveChangesAsync();

                if (!_cache.TryGetValue("Legalidades", out List<Legalidade>? legalidades))
                {
                    legalidades = await _context.Legalidade.Include(x => x.Carta).ToListAsync();
                }
                legalidades.Add(legalidade);

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };

                _cache.Set("Legalidades", legalidade, cacheEntryOptions);

                return RedirectToAction(nameof(Index));
            }
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome", legalidade.CartaId);
            return View(legalidade);
        }

        // GET: Legalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Legalidade == null)
            {
                return NotFound();
            }

            if (!_cache.TryGetValue($"Legalidade_{id}", out Legalidade? legalidade))
            {
                legalidade = await _context.Legalidade
                    .Include(l => l.Carta)
                    .FirstOrDefaultAsync(m => m.Id == id);

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };

                if (legalidade != null)
                {
                    _cache.Set($"Legalidade_{id}", legalidade, cacheEntryOptions);
                }
            }

            if (legalidade == null)
            {
                return NotFound();
            }
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome", legalidade.CartaId);
            return View(legalidade);
        }

        // POST: Legalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Formato,Legal,CartaId")] Legalidade legalidade)
        {
            if (id != legalidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legalidade);
                    await _context.SaveChangesAsync();

                    _cache.Remove($"Legalidade_{id}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegalidadeExists(legalidade.Id))
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
            ViewData["CartaId"] = new SelectList(_context.Cartas, "Id", "Nome", legalidade.CartaId);
            return View(legalidade);
        }

        // GET: Legalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Legalidade == null)
            {
                return NotFound();
            }

            if (!_cache.TryGetValue($"Legalidade_{id}", out Legalidade? legalidade))
            {
                legalidade = await _context.Legalidade
                    .Include(l => l.Carta)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (legalidade != null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                        SlidingExpiration = TimeSpan.FromMinutes(2),
                        Size = 1024,
                    };

                    _cache.Set($"Legalidade_{id}", legalidade, cacheEntryOptions);
                }
            }

            if (legalidade == null)
            {
                return NotFound();
            }

            return View(legalidade);
        }

        // POST: Legalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Legalidade == null)
            {
                return Problem("Entity set 'OracleDbContext.Legalidade'  is null.");
            }

            if (!_cache.TryGetValue($"Legalidade_{id}", out Legalidade? legalidade))
            {
                legalidade = await _context.Legalidade.FindAsync(id);

                if (legalidade != null)
                {
                    _context.Legalidade.Remove(legalidade);
                    await _context.SaveChangesAsync();
                    _cache.Remove($"Legalidade_{id}");
                }
            }

            if (legalidade != null)
            {
                _context.Legalidade.Remove(legalidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegalidadeExists(int id)
        {
          return (_context.Legalidade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
