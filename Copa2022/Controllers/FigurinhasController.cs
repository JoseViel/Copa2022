using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Copa2022.Models;

namespace Copa2022.Controllers
{
    public class FigurinhasController : Controller
    {
        private readonly Contexto _context;

        public FigurinhasController(Contexto context)
        {
            _context = context;
        }

        // GET: Figurinhas
        public async Task<IActionResult> Index()
        {
              return View(await _context.figurinhas.ToListAsync());
        }

        // GET: Figurinhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.figurinhas == null)
            {
                return NotFound();
            }

            var figurinha = await _context.figurinhas
                .FirstOrDefaultAsync(m => m.id == id);
            if (figurinha == null)
            {
                return NotFound();
            }

            return View(figurinha);
        }

        // GET: Figurinhas/Create
        public IActionResult Create()
        {
            var raridade = Enum.GetValues(typeof(Raridade))
           .Cast<Raridade>()
           .Select(e => new SelectListItem
           {
               Value = e.ToString(),
               Text = e.ToString()
           });

            ViewBag.bagRaridade = raridade;

            return View();
        }

        // POST: Figurinhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,jogador,venda,compra,pais,posicao,raridade")] Figurinha figurinha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(figurinha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(figurinha);
        }

        // GET: Figurinhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.figurinhas == null)
            {
                return NotFound();
            }

            var figurinha = await _context.figurinhas.FindAsync(id);
            if (figurinha == null)
            {
                return NotFound();
            }
            return View(figurinha);
        }

        // POST: Figurinhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,jogador,venda,compra,pais,posicao,raridade")] Figurinha figurinha)
        {
            if (id != figurinha.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(figurinha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FigurinhaExists(figurinha.id))
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
            return View(figurinha);
        }

        // GET: Figurinhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.figurinhas == null)
            {
                return NotFound();
            }

            var figurinha = await _context.figurinhas
                .FirstOrDefaultAsync(m => m.id == id);
            if (figurinha == null)
            {
                return NotFound();
            }

            return View(figurinha);
        }

        // POST: Figurinhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.figurinhas == null)
            {
                return Problem("Entity set 'Contexto.figurinhas'  is null.");
            }
            var figurinha = await _context.figurinhas.FindAsync(id);
            if (figurinha != null)
            {
                _context.figurinhas.Remove(figurinha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FigurinhaExists(int id)
        {
          return _context.figurinhas.Any(e => e.id == id);
        }
    }
}
