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
    public class ColecoesController : Controller
    {
        private readonly OracleDbContext _context;
        private readonly IMemoryCache _cache;

        public ColecoesController(OracleDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Colecoes
        public async Task<IActionResult> Index()
        {
            if (!_cache.TryGetValue("Colecoes", out List<Colecao> colecoes))
            {
                colecoes = await _context.Colecao.ToListAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };
                _cache.Set("Colecoes", colecoes, cacheEntryOptions);
                return View(colecoes);
            }
            return View(colecoes);
        }

        // GET: Colecoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colecao == null)
            {
                return NotFound();
            }

            if (!_cache.TryGetValue($"Colecao_{id}", out Colecao? colecao))
            {
                colecao = await _context.Colecao.FirstOrDefaultAsync(m => m.Id == id);

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };

                if (colecao != null)
                {
                    _cache.Set($"Colecao_{id}", colecao, cacheEntryOptions);
                }
            }
            if (colecao == null)
            {
                return NotFound();
            }

            return View(colecao);
        }

        // GET: Colecoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colecoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataLancamento,Idioma")] Colecao colecao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colecao);
                await _context.SaveChangesAsync();

                if (!_cache.TryGetValue("Colecoes", out List<Colecao>? colecoes))
                {
                    colecoes = await _context.Colecao.ToListAsync();
                }
                colecoes.Add(colecao);

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };

                _cache.Set("Colecoes", colecoes, cacheEntryOptions);

                return RedirectToAction(nameof(Index));
            }
            return View(colecao);
        }

        // GET: Colecoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colecao == null)
            {
                return NotFound();
            }

            if (!_cache.TryGetValue($"Colecao_{id}", out Colecao? colecao))
            {
                colecao = await _context.Colecao.FindAsync(id);

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };

                if (colecao != null)
                {
                    _cache.Set($"Colecao_{id}", colecao, cacheEntryOptions);
                }
            }

            if (colecao == null)
            {
                return NotFound();
            }
            return View(colecao);
        }

        // POST: Colecoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataLancamento,Idioma")] Colecao colecao)
        {
            if (id != colecao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colecao);
                    await _context.SaveChangesAsync();

                    _cache.Remove($"Colecao_{id}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColecaoExists(colecao.Id))
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
            return View(colecao);
        }

        // GET: Colecoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colecao == null)
            {
                return NotFound();
            }

            if (!_cache.TryGetValue($"Colecao_{id}", out Colecao? colecao))
            {
                colecao = await _context.Colecao.FirstOrDefaultAsync(m => m.Id == id);
                
                if (colecao != null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                        SlidingExpiration = TimeSpan.FromMinutes(2),
                        Size = 1024,
                    };

                    _cache.Set($"Colecao_{id}", colecao, cacheEntryOptions);
                }
            }

            if (colecao == null)
            {
                return NotFound();
            }

            return View(colecao);
        }

        // POST: Colecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colecao == null)
            {
                return Problem("Entity set 'OracleDbContext.Colecao'  is null.");
            }

            if (!_cache.TryGetValue($"Colecao_{id}", out Colecao? colecao))
            {
                colecao = await _context.Colecao.FindAsync(id);

                if (colecao != null)
                {
                    _context.Colecao.Remove(colecao);
                    await _context.SaveChangesAsync();
                    _cache.Remove($"Colecao_{id}");
                }
            }

            if (colecao != null)
            {
                _context.Colecao.Remove(colecao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColecaoExists(int id)
        {
          return (_context.Colecao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
