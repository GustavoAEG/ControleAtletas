using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleAtletas.Context;
using ControleAtletas.Models;

namespace ControleAtletas.Controllers
{
    public class AtletaController : Controller
    {
        private readonly AppDbContext _context;

        public AtletaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Atleta
        public async Task<IActionResult> Index()
        {
              return _context.Atleta != null ? 
                          View(await _context.Atleta.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Atleta'  is null.");
        }

        // GET: Atleta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atleta == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .FirstOrDefaultAsync(m => m.AtletaID == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        // GET: Atleta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atleta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AtletaID,NomeCompleto,Apelido,DataNascimento,Altura,Peso,Posicao,NumeroCamisa")] Atleta atleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atleta);
        }

        // GET: Atleta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atleta == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta == null)
            {
                return NotFound();
            }
            return View(atleta);
        }

        // POST: Atleta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AtletaID,NomeCompleto,Apelido,DataNascimento,Altura,Peso,Posicao,NumeroCamisa")] Atleta atleta)
        {
            if (id != atleta.AtletaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtletaExists(atleta.AtletaID))
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
            return View(atleta);
        }

        // GET: Atleta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atleta == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .FirstOrDefaultAsync(m => m.AtletaID == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        // POST: Atleta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atleta == null)
            {
                return Problem("Entity set 'AppDbContext.Atleta'  is null.");
            }
            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta != null)
            {
                _context.Atleta.Remove(atleta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtletaExists(int id)
        {
          return (_context.Atleta?.Any(e => e.AtletaID == id)).GetValueOrDefault();
        }
    }
}
