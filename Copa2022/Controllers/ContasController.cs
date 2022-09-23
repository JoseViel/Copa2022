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
    public class ContasController : Controller
    {
        private readonly Contexto _context;

        public ContasController(Contexto context)
        {
            _context = context;
        }

        // GET: Contas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.contas.Include(c => c.cliente).Include(c => c.figurinha);
            return View(await contexto.ToListAsync());
        }

        // GET: Contas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.contas == null)
            {
                return NotFound();
            }

            var conta = await _context.contas
                .Include(c => c.cliente)
                .Include(c => c.figurinha)
                .FirstOrDefaultAsync(m => m.id == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // GET: Contas/Create
        public IActionResult Create()
        {
            ViewData["clienteid"] = new SelectList(_context.clientes, "id", "cidade");
            ViewData["figurinhaid"] = new SelectList(_context.figurinhas, "id", "jogador");
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,clienteid,figurinhaid,quantidade")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["clienteid"] = new SelectList(_context.clientes, "id", "cidade", conta.clienteid);
            ViewData["figurinhaid"] = new SelectList(_context.figurinhas, "id", "jogador", conta.figurinhaid);
            return View(conta);
        }

        // GET: Contas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.contas == null)
            {
                return NotFound();
            }

            var conta = await _context.contas.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }
            ViewData["clienteid"] = new SelectList(_context.clientes, "id", "cidade", conta.clienteid);
            ViewData["figurinhaid"] = new SelectList(_context.figurinhas, "id", "jogador", conta.figurinhaid);
            return View(conta);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,clienteid,figurinhaid,quantidade")] Conta conta)
        {
            if (id != conta.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaExists(conta.id))
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
            ViewData["clienteid"] = new SelectList(_context.clientes, "id", "cidade", conta.clienteid);
            ViewData["figurinhaid"] = new SelectList(_context.figurinhas, "id", "jogador", conta.figurinhaid);
            return View(conta);
        }

        // GET: Contas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.contas == null)
            {
                return NotFound();
            }

            var conta = await _context.contas
                .Include(c => c.cliente)
                .Include(c => c.figurinha)
                .FirstOrDefaultAsync(m => m.id == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // POST: Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.contas == null)
            {
                return Problem("Entity set 'Contexto.contas'  is null.");
            }
            var conta = await _context.contas.FindAsync(id);
            if (conta != null)
            {
                _context.contas.Remove(conta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaExists(int id)
        {
          return _context.contas.Any(e => e.id == id);
        }
    }
}
