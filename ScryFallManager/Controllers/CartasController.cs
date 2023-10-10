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
    public class CartasController : Controller
    {
        private readonly OracleDbContext _context;
        private readonly IMemoryCache _cache;

        public CartasController(OracleDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Cartas
        public async Task<IActionResult> Index()
        {
            if (!_cache.TryGetValue("Cartas", out List<Carta> cartas))
            {
                cartas = await _context.Cartas.Include(c => c.Colecao).ToListAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };
                _cache.Set("Cartas", cartas, cacheEntryOptions);
                return View(cartas);
            }
            return View(cartas);
        }

        // GET: Cartas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cartas == null)
            {
                return NotFound();
            }

            if (!_cache.TryGetValue($"Carta_{id}", out Carta? carta))
            {
                carta = await _context.Cartas
                    .Include(c => c.Colecao)
                    .FirstOrDefaultAsync(m => m.Id == id);

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };

                if (carta != null)
                {
                    _cache.Set($"Carta_{id}", carta, cacheEntryOptions);
                }
            }

            
            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // GET: Cartas/Create
        public IActionResult Create()
        {

            if (!_cache.TryGetValue("CreateSelectList", out IEnumerable<SelectListItem> SelectColecaoList)) {
                SelectColecaoList = _context.Colecao.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nome }).ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };

                _cache.Set("CreateSelectList", SelectColecaoList, cacheEntryOptions);
            }

            ViewData["ColecaoId"] = new SelectList(SelectColecaoList, "Id", "Id");
            return View();
        }

        // POST: Cartas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Texto,Raridade,Idioma,CustoMana,DataLancamento,ColecaoId")] Carta carta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (!_cache.TryGetValue("CreateSelectList", out IEnumerable<SelectListItem> SelectColecaoList))
            {
                SelectColecaoList = _context.Colecao.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nome }).ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };

                _cache.Set("CreateSelectList", SelectColecaoList, cacheEntryOptions);
            }

            ViewData["ColecaoId"] = new SelectList(_context.Colecao, "Id", "Id", carta.ColecaoId);
            return View(carta);
        }

        // GET: Cartas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cartas == null)
            {
                return NotFound();
            }

            var carta = await _context.Cartas.FindAsync(id);
            if (carta == null)
            {
                return NotFound();
            }
            ViewData["ColecaoId"] = new SelectList(_context.Colecao, "Id", "Id", carta.ColecaoId);
            return View(carta);
        }

        // POST: Cartas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Texto,Raridade,Idioma,CustoMana,DataLancamento,ColecaoId")] Carta carta)
        {
            if (id != carta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaExists(carta.Id))
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
            ViewData["ColecaoId"] = new SelectList(_context.Colecao, "Id", "Id", carta.ColecaoId);
            return View(carta);
        }

        // GET: Cartas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cartas == null)
            {
                return NotFound();
            }

            var carta = await _context.Cartas
                .Include(c => c.Colecao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // POST: Cartas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cartas == null)
            {
                return Problem("Entity set 'OracleDbContext.Cartas'  is null.");
            }
            var carta = await _context.Cartas.FindAsync(id);
            if (carta != null)
            {
                _context.Cartas.Remove(carta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaExists(int id)
        {
          return (_context.Cartas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
